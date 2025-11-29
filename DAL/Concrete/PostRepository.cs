using DAL.Abstract;
using Dapper;
using Domain;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DAL.Concrete
{
    public class PostRepository : IPostRepository
    {
        public void CreatePost(Post post)
        {
            string sql = "INSERT INTO Post (Author, Content) Values (@Author, @Content)";

            using(var connection = new SqlConnection(DatabaseOptions.DatabaseConnectionString))
            {
                connection.Execute(sql, new { Author = post.Author, Content = post.Content});
            }
        }

        public IList<Post> GetPosts()
        {
            List<Post> posts;
            string sql = "SELECT * FROM Post WHERE Created >= DATEADD(day, -1, GETDATE()) ORDER BY Created DESC";

            using (var connection = new SqlConnection(DatabaseOptions.DatabaseConnectionString))
            {
                posts = connection.Query<Post>(sql).ToList();
            }

            return posts;
        }
    }
}
