using System.ComponentModel.DataAnnotations;
namespace MyBlog.Web.ViewModels.Account;
public class RegisterViewModel
{
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "نام کاربری اجباری است")]
    [MaxLength(50, ErrorMessage = "نام کاربری نمی تواند بزرگ تر از 50 کاراکتر باشد")]
    [DataType(DataType.Text)]
    public string UserName { get; set; }
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "ایمیل را وارد کنید")]
    [MaxLength(50, ErrorMessage = "ایمیل نمی تواند بزرگ تر از 50 کاراکتر باشد")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "کلمه عبور اجباری است")]
    [MaxLength(50, ErrorMessage = "کلمه عبور نمی تواند بزرگ تر از 50 کاراکتر باشد")]
    public string Password { get; set; }
}
public enum RegisterResult
{
    Success,
    Error,
    EmailExist
}