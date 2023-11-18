using MyBlog.Web.Models.Account;
using MyBlog.Web.ViewModels.Account;
using MyBlog.Web.ViewModels.Users;

namespace MyBlog.Web.Services.Interface;
public interface IUserService : IAsyncDisposable
{
    #region user

    Task<bool> IsUserEmailExist(string email);

    Task<RegisterResult> RegisterUser(RegisterViewModel register);

    Task<User> GetUserByEmail(string email);

    Task<LoginResult> LoginUser(LoginViewModel login);

    #endregion

    #region user for admin
    UsersViewModel GetUsers(int pageId = 1,string email = "",string userName = "");
    #endregion
}