using BLL.Abstract;
using DAL.Abstract;
using DataContract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void CreatePost(PostDto dto)
        {
            try
            {
                var post = new Post
                {
                    Author = dto.Author,
                    Content = dto.Content.Replace("\n", "<br />"),
                    Created = dto.Created,
                    Id = dto.Id,
                };

                _postRepository.CreatePost(post);
            }
            catch (Exception)
            {
                // În Azure, dacă DB nu e configurată corect, evităm să „pice” aplicația.
                // Într-un proiect real am scrie aici log (Serilog, ILogger etc).
            }
        }

        public IList<PostDto> GetPosts()
        {
            try
            {
                var posts = _postRepository.GetPosts();

                var dtos = posts.Select(x => new PostDto
                {
                    Author = x.Author,
                    Content = x.Content,
                    Created = x.Created,
                    Id = x.Id
                }).ToList();

                return dtos;
            }
            catch (Exception)
            {
                // Dacă în Azure DB nu este accesibilă → întoarcem listă goală,
                // iar Home/Index afișează mesajul „No posts...”, nu pagina de eroare.
                return new List<PostDto>();
            }
        }
    }
}
