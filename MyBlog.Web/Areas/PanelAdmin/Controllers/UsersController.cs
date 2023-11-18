using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Services.Interface;
using MyBlog.Web.ViewModels.Users;

namespace MyBlog.Web.Areas.PanelAdmin.Controllers;
public class UsersController : AdminController
{
    #region Construcotr
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    #endregion
    public UsersViewModel UsersViewModel { get; set; }

    #region Users List
    [HttpGet("UsersList")]
    public IActionResult UsersList(int pageId = 1, string email = "", string userName = "")
    {
        UsersViewModel = _userService.GetUsers(pageId, email, userName);
        return View(UsersViewModel);
    }
    #endregion
}