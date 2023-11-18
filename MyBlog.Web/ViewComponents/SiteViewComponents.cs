using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Services.Interface;
using MyBlog.Web.ViewModels.Posts;

namespace MyBlog.Web.ViewComponents;

#region Site Header 
public class SiteHeaderViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("SiteHeader");
    }
}
#endregion

#region Site footer 
public class SiteFooterViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("SiteFooter");
    }
}
#endregion

#region Last Post
public class LastPostViewComponent : ViewComponent
{
    private readonly IPostService _postService;
    public LastPostViewComponent(IPostService postService)
    {
        _postService = postService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.post = _postService.GetLastPosts(4);
        return View("LastPost");
    }
}
#endregion