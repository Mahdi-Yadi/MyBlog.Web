using Microsoft.AspNetCore.Mvc;
namespace MyBlog.Web.Controllers;
public class PostController : NotificationController
{
    #region Constructor



    #endregion

    #region Posts Filter
    [HttpGet("PostsFilter")]
    public IActionResult PostsFilter()
    {
        return View();
    }

    #endregion

    #region Post Detail
    [HttpGet("PostDetail")]
    public IActionResult PostDetail()
    {
        return View();
    }

    #endregion
}