using MyBlog.Web.Models.Categories;
using MyBlog.Web.ViewModels.Category;
namespace MyBlog.Web.Services.Interface;
public interface ICategoryService
{
    List<CategoryForAdminViewModel> GetCatForAdmin();
    int AddCategory(CategoryForAdminViewModel category);
    void EditCategory(Category category);
    bool DeleteCategory(int categoryId);
    Category GetCategoryById(int categoryId);
}