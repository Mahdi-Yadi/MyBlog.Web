using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Http;
using MyBlog.Web.Models.Categories;
using MyBlog.Web.Models.Posts;
using MyBlog.Web.Services.Implemtations;
using MyBlog.Web.Services.Interface;
using MyBlog.Web.ViewModels.Category;
using MyBlog.Web.ViewModels.Posts;
namespace MyBlog.Web.Areas.PanelAdmin.Controllers;
public class CategoriesController : AdminController
{
    #region Constructor
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    #endregion

    #region Category List
    [HttpGet("CategoryList")]
    public IActionResult CategoryList(List<CategoryForAdminViewModel> cat)
    {
        cat = _categoryService.GetCatForAdmin();
        if (cat == null)
        {
            return Redirect("Panel/Home");
        }
        return View(cat);
    }
    #endregion

    #region Category Post
    [HttpGet("Create-Category")]
    public IActionResult CreateCategory()
    {
        return View();
    }
    [HttpPost("Create-Category"), ValidateAntiForgeryToken]
    public IActionResult CreateCategory(CategoryForAdminViewModel category)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("CategoryList");
        _categoryService.AddCategory(category);
        return RedirectToAction("CategoryList");
    }
    #endregion

    #region Edit Category
    [HttpGet("/EditCategory/{categoryId}")]
    public IActionResult EditCategory(int categoryId)
    {
        var cat = _categoryService.GetCategoryById(categoryId);
        if (cat == null)
        {
            return View();
        }
        return View(cat);
    }
    [HttpPost("/EditCategory/{categoryId}")]
    public IActionResult EditCategory(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _categoryService.EditCategory(category);
        return Redirect("/Panel/CategoryList");
    }
    #endregion

    #region Delete Category
    [HttpGet("/DeleteCategory/{categoryId}")]
    public IActionResult DeleteCategory(int categoryId)
    {
        var cat = _categoryService.DeleteCategory(categoryId);
        if (cat)
        {
            return JsonStatus.SendStatus(JsonResponseStatusType.Success, "دسته بندی با موفقیت حذف شد", null);
        }
        return JsonStatus.SendStatus(JsonResponseStatusType.Warning, "دسته بندی یافت نشد!", null);
    }
    #endregion
}