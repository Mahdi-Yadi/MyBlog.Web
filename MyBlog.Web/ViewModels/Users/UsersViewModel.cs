using MyBlog.Web.Models.Account;
namespace MyBlog.Web.ViewModels.Users;
public class UsersViewModel
{
    public List<User> Users { get; set; }
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
}