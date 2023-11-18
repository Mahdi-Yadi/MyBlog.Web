using MyBlog.Web.Models.Categories;
using MyBlog.Web.Models.Posts;
using MyBlog.Web.ViewModels.Posts;
namespace MyBlog.Web.Services.Interface;
public interface IPostService
{
    List<PostForAdminViewModel> GetPostForAdmin();
    int AddPost(Post post, IFormFile postImage);
    Post GetPostById(int postId);
    void EditPost(Post post,IFormFile postImage);
    bool DeletePost(int postId);
    List<Post> GetLastPosts(int take);
    List<Post> GetLastPostsByVisited(int take);
    List<Post> GetLastSpecialPosts(int take);
    List<Category> GetCatForPost();
}