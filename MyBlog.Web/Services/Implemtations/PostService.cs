using MyBlog.Web.Data;
using MyBlog.Web.Models.Categories;
using MyBlog.Web.Models.Posts;
using MyBlog.Web.Services.Interface;
using MyBlog.Web.ViewModels.Posts;
namespace MyBlog.Web.Services.Implemtations;
public class PostService : IPostService
{
    #region Constructor
    private readonly MyBlogContext _ctx;
    public PostService(MyBlogContext ctx)
    {
        _ctx = ctx;
    }
    #endregion

    #region Post For Admin
    public List<PostForAdminViewModel> GetPostForAdmin()
    {
        return _ctx.Posts.Select(p => new PostForAdminViewModel()
        {
            PostId = p.Id,
            PostTitle = p.Title,
            ImageName = p.ImageName,
            CreateDate = p.CreateDate,
            IsSpecial = p.IsSpecial
        }).ToList();
    }
    public int AddPost(Post post, IFormFile postImage)
    {
        var newPost = new Post();
        if (postImage != null)
        {
            newPost.ImageName = Guid.NewGuid().ToString("N") + Path.GetExtension(postImage.FileName);
            string imagPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/common/images/", newPost.ImageName);
            using (var st = new FileStream(imagPath, FileMode.Create))
            {
                postImage.CopyTo(st);
            }
        }
        else
        {
            newPost.ImageName = "Defualt.png";
        }

        newPost.CreateDate = DateTime.Now;
        newPost.Update = DateTime.Now;
        newPost.CategoryId = post.CategoryId;
        newPost.IsSpecial = post.IsSpecial;
        newPost.Description = post.Description;
        newPost.Title = post.Title;
        _ctx.Add(newPost);
        _ctx.SaveChanges();
        return post.Id;
    }
    public Post GetPostById(int postId)
    {
        return _ctx.Posts.Find(postId);
    }
    public void EditPost(Post post, IFormFile postImage)
    {
        var Lastpost = GetPostById(post.Id);
        Lastpost.Update = DateTime.Now;
        Lastpost.IsSpecial = post.IsSpecial;
        Lastpost.Description = post.Description;
        Lastpost.Title = post.Title;
        if (postImage != null)
        {
            if (post.ImageName != "Defualt.png")
            {
                string deleteOldImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/common/images/", post.ImageName);
                if (deleteOldImage != null)
                {
                    if (File.Exists(deleteOldImage))
                    {
                        File.Delete(deleteOldImage);
                    }
                }
            }
            Lastpost.ImageName = Guid.NewGuid().ToString("N") + Path.GetExtension(postImage.FileName);
            string imagPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/common/images/", Lastpost.ImageName);
            using (var st = new FileStream(imagPath, FileMode.Create))
            {
                postImage.CopyTo(st);
            }
        }
        _ctx.Update(Lastpost);
        _ctx.SaveChanges();
    }
    public bool DeletePost(int postId)
    {
        var post = _ctx.Posts.Find(postId);
        if (post == null)
            return false;
        _ctx.Remove(post);
        _ctx.SaveChanges();
        return true;
    }
    public List<Category> GetCatForPost()
    {
        return _ctx
            .Categories.ToList();
    }
    #endregion

    #region Post For Site
    public List<Post> GetLastPosts(int take)
    {
        return _ctx.Posts
            .OrderByDescending(p => p.CreateDate)
            .Skip(0)
            .Take(take)
            .Distinct()
            .ToList();
    }
    public List<Post> GetLastPostsByVisited(int take)
    {
        return _ctx.Posts
            .OrderByDescending(p => p.CreateDate)
            .OrderByDescending(p => p.Visited)
            .Skip(0)
            .Take(take)
            .Distinct()
            .ToList();
    }
    public List<Post> GetLastSpecialPosts(int take)
    {
        return _ctx.Posts
            .Where(p => p.IsSpecial)
            .OrderByDescending(p => p.Update)
            .Skip(0)
            .Take(take)
            .Distinct()
            .ToList();
    }
    #endregion
}