using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Services.Interface;

namespace MyBlog.Web.Controllers;
public class HomeController : NotificationController
{
    #region Constructor
    private readonly IPostService _postService;
    public HomeController(IPostService postService)
    {
        _postService = postService;
    }
    #endregion

    #region Home
    public IActionResult Index()
    {
        ViewBag.lastpost = _postService.GetLastPostsByVisited(2);
        ViewBag.specialpost = _postService.GetLastSpecialPosts(1);
        return View();
    }
    #endregion

    #region About Us
    [HttpGet("AboutUs")]
    public IActionResult AboutUs()
    {
        return View();
    }
    #endregion

    #region Contact Us
    [HttpGet("ContactUs")]
    public IActionResult ContactUs()
    {
        return View();
    }
    #endregion
}