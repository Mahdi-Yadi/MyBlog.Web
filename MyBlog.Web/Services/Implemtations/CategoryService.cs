using MyBlog.Web.Data;
using MyBlog.Web.Models.Categories;
using MyBlog.Web.Models.Posts;
using MyBlog.Web.Services.Interface;
using MyBlog.Web.ViewModels.Category;
namespace MyBlog.Web.Services.Implemtations;
public class CategoryService : ICategoryService
{
    #region Constructor
    private readonly MyBlogContext _ctx;
    public CategoryService(MyBlogContext ctx)
    {
        _ctx = ctx;
    }
    #endregion

    #region Category For Admin
    public List<CategoryForAdminViewModel> GetCatForAdmin()
    {
        return _ctx.Categories.Select(p => new CategoryForAdminViewModel()
        {
           CatId = p.Id,
           Title = p.Name
        }).ToList();
    }
    public int AddCategory(CategoryForAdminViewModel category)
    {
        var cat = new Category();
        cat.Name = category.Title;
        _ctx.Add(cat);
        _ctx.SaveChanges();
        return cat.Id;
    }
    public void EditCategory(Category category)
    {
        var cat = GetCategoryById(category.Id);
        cat.Name = category.Name;
        _ctx.Update(cat);
        _ctx.SaveChanges();
    }
    public bool DeleteCategory(int categoryId)
    {
        var cat = _ctx.Categories.Find(categoryId);
        if (cat == null)
            return false;
        var post = _ctx.Posts.Where(p => p.Category.Id == cat.Id).ToList();
        foreach(var item in post)
        {
            item.Category.Id = 0;
        }
        _ctx.Remove(cat);
        _ctx.SaveChanges();
        return true;
    }
    public Category GetCategoryById(int categoryId)
    {
        return _ctx.Categories.Find(categoryId);
    }
    #endregion
}