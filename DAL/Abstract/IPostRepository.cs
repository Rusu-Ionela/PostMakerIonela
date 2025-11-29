using Domain;

namespace DAL.Abstract
{
    public interface IPostRepository
    {
        IList<Post> GetPosts();

        void CreatePost(Post post);
    }
}
