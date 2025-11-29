using DataContract;

namespace BLL.Abstract
{
    public interface IPostService
    {
        IList<PostDto> GetPosts();


        void CreatePost(PostDto dto);  
    }
}
