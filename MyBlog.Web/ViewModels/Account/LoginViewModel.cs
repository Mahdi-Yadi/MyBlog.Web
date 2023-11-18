using System.ComponentModel.DataAnnotations;

namespace MyBlog.Web.ViewModels.Account;
public class LoginViewModel
{
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "ایمیل را وارد کنید")]
    [MaxLength(50, ErrorMessage = "ایمیل نمی تواند بزرگ تر از 50 کاراکتر باشد")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "کلمه عبور اجباری است")]
    [MaxLength(50, ErrorMessage = "کلمه عبور نمی تواند بزرگ تر از 50 کاراکتر باشد")]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
public enum LoginResult
{
    Error,
    Nofound,
    Success
}