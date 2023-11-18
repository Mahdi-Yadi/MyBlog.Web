using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Services.Interface;
using MyBlog.Web.ViewModels.Account;
using System.Security.Claims;
namespace MyBlog.Web.Controllers;
public class AccountController : NotificationController
{
    #region Constructor
    private readonly IUserService _userService;
    public AccountController(IUserService userService)
    {
        _userService = userService;
    }
    #endregion

    #region Register
    [HttpGet("Register")]
    public IActionResult Register()
    {
        if (User.Identity.IsAuthenticated)
        {
            TempData[ErrorMessage] = "شما قبلا وارد شده اید :)";
            return Redirect("/");
        }
        return View();
    }
    [HttpPost("Register"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel register)
    {
        if (ModelState.IsValid)
        {
            var res = await _userService.RegisterUser(register);
            switch (res)
            {
                case RegisterResult.EmailExist:
                    TempData[WarningMessage] = "ایمیل وارد شده تکراری است";
                    break;
                case RegisterResult.Error:
                    TempData[ErrorMessage] = "لطفا نام کاربری را وارد کنید";
                    break;
                case RegisterResult.Success:
                    TempData[SuccessMessage] = "ثبت نام شما با موفقیت انجام شد";
                    return Redirect("Login");
            }
        }
        return View(register);
    }
    #endregion

    #region Login
    [HttpGet("Login")]
    public IActionResult Login()
    {
        if (User.Identity.IsAuthenticated)
        {
            TempData[WarningMessage] = "شما قبلا وارد شده اید";
            return Redirect("/");
        }
        return View();
    }
    [HttpPost("Login"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel login)
    {
        if (ModelState.IsValid)
        {
            var res = await _userService.LoginUser(login);
            switch (res)
            {
                case LoginResult.Error:
                    TempData[ErrorMessage] = "اطلاعات یافت نشد";
                    break;
                case LoginResult.Nofound:
                    TempData[WarningMessage] = "کاربری یافت نشد";
                    break;
                case LoginResult.Success:
                    var user = await _userService.GetUserByEmail(login.Email);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name , user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                    };
                    var identity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent= login.RememberMe
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults
                        .AuthenticationScheme,
                        new ClaimsPrincipal(identity), properties);
                    TempData[SuccessMessage] = "ورود با موفقیت انجام شد";
                    return Redirect("/");
            }
        }
        return View(login);
    }
    #endregion

    #region ForgotPassword
    [HttpGet("ForgotPassword")]
    public IActionResult ForgotPassword()
    {
        return View();
    }
    #endregion

    #region ResetPassword
    [HttpGet("ResetPassword")]
    public IActionResult ResetPassword()
    {
        return View();
    }
    #endregion

    #region Logout
    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        if (!User.Identity.IsAuthenticated) return Redirect("/");
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
        TempData[InfoMessage] = "شما از حساب کاربری خارج شدید";
        return Redirect("/");
    }
    #endregion
}