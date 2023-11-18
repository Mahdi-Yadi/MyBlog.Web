using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Http;
using MyBlog.Web.Models.Posts;
using MyBlog.Web.Services.Interface;
using MyBlog.Web.ViewModels.Posts;
namespace MyBlog.Web.Areas.PanelAdmin.Controllers;
public class PostsController : AdminController
{
    #region Constructor
    private readonly IPostService _postService;
    public PostsController(IPostService postService)
    {
        _postService = postService;
    }
    #endregion

    #region Posts List
    [HttpGet("PostsList")]
    public IActionResult PostsList(List<PostForAdminViewModel> post)
    {
        post = _postService.GetPostForAdmin();
        if(post == null)
        {
            return Redirect("Panel/Home");
        }
        return View(post);
    }
    #endregion

    #region Create Post
    [HttpGet("Create-Post")]
    public IActionResult CreatePost()
    {
        ViewBag.cat = _postService.GetCatForPost();
        return View();
    }
    [HttpPost("Create-Post"),ValidateAntiForgeryToken]
    public IActionResult CreatePost(Post post,IFormFile postImage)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("PostsList");
        ViewBag.cat = _postService.GetCatForPost();
        _postService.AddPost(post,postImage);
        return RedirectToAction("PostsList");
    }
    #endregion

    #region Edit Post
    [HttpGet("Panel/EditPost/{postId}")]
    public IActionResult EditPost(int postId)
    {
        var post = _postService.GetPostById(postId);
        if(post == null)
        {
            return View();
        }
        ViewBag.cat = _postService.GetCatForPost();
        return View(post);
    }
    [HttpPost("Panel/EditPost/{postId}")]
    public IActionResult EditPost(Post post,IFormFile postImage)
    {
        if(!ModelState.IsValid)
        {
            return View();
        }
        ViewBag.cat = _postService.GetCatForPost();
        _postService.EditPost(post, postImage);
        return Redirect("/Panel/PostsList");
    }
    #endregion

    #region Delete Post
    [HttpGet("Panel/DeletePost/{postId}")]
    public IActionResult DeletePost(int postId)
    {
        var post = _postService.DeletePost(postId);
        if(post)
        {
            return JsonStatus.SendStatus(JsonResponseStatusType.Success, "مقاله با موفقیت حذف شد", null);
        }
        return JsonStatus.SendStatus(JsonResponseStatusType.Warning, "مقاله یافت نشد!", null);
    }
    #endregion
}