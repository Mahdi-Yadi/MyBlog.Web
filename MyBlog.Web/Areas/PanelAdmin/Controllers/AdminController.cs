using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MyBlog.Web.Areas.PanelAdmin.Controllers;
[Area("PanelAdmin")]
[Route("Panel")]
[Authorize]
public class AdminController : Controller
{
    protected string SuccessMessage = "SuccessMessage";
    protected string ErrorMessage = "ErrorMessage";
    protected string WarningMessage = "WarningMessage";
    protected string InfoMessage = "SuccessMessage";
}