using Microsoft.AspNetCore.Mvc;
namespace MyBlog.Web.Areas.PanelAdmin.Controllers;
public class HomeController : AdminController
{
    [HttpGet("Home")]
    public IActionResult Index()
    {
        return View();
    }
}