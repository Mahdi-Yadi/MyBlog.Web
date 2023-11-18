using Microsoft.EntityFrameworkCore;
using MyBlog.Web.Data;
using MyBlog.Web.Models.Account;
using MyBlog.Web.Security;
using MyBlog.Web.Services.Interface;
using MyBlog.Web.ViewModels.Account;
using MyBlog.Web.ViewModels.Users;

namespace MyBlog.Web.Services.Implemtations;
public class UserService : IUserService
{
    #region Db
    private readonly MyBlogContext _ctx;
    public UserService(MyBlogContext ctx)
    {
        _ctx = ctx;
    }
    #endregion

    #region user
    public async Task<bool> IsUserEmailExist(string email)
    {
        return await _ctx.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<RegisterResult> RegisterUser(RegisterViewModel register)
    {
        if (await IsUserEmailExist(register.Email))
            return RegisterResult.EmailExist;
        if (register.UserName == null)
            return RegisterResult.Error;
        var user = new User()
        {
            UserName = register.UserName,
            Email = SiteSecurity.FixEmail(register.Email),
            Password = SiteSecurity.EncodePasswordMd5(register.Password),
            CreateDate = DateTime.Now
        };
        await _ctx.Users.AddAsync(user);
        await _ctx.SaveChangesAsync();
        return RegisterResult.Success;
    }
    public async Task<User> GetUserByEmail(string email)
    {
        return await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<LoginResult> LoginUser(LoginViewModel login)
    {
        var user = await GetUserByEmail(login.Email);
        if (user == null) return LoginResult.Nofound;
        if (user.Password != SiteSecurity.EncodePasswordMd5(login.Password)) return LoginResult.Error;
        return LoginResult.Success;
    }
    #endregion

    #region user for admin
    public UsersViewModel GetUsers(int pageId = 1, string email = "", string userName = "")
    {
        IQueryable<User> result = _ctx.Users;

        if(!string.IsNullOrEmpty(email))
        {
            result = result.Where(u => u.Email.Contains(email));
        }
        if(!string.IsNullOrEmpty(userName))
        {
            result = result.Where(u => u.UserName.Contains(userName));
        }
        int take = 10;
        int skip = (pageId - 1) * take;

        UsersViewModel list = new UsersViewModel();
        list.CurrentPage = pageId;
        list.PageCount = result.Count() / take;
        list.Users = result.OrderBy(u => u.CreateDate).Skip(skip).Take(take).ToList();
        return list;
    }
    #endregion

    public async ValueTask DisposeAsync()
    {
        if (_ctx != null) await _ctx.DisposeAsync();
    }

}