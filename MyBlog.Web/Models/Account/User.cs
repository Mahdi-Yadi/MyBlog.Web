using System.ComponentModel.DataAnnotations;
using MyBlog.Web.Models.Posts;
namespace MyBlog.Web.Models.Account;
public class User
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "نام کاربری")]
    [Required]
    [MaxLength(50,ErrorMessage = "نام کاربری نمی تواند بزرگ تر از 50 کاراکتر باشد")]
    [DataType(DataType.Text)]
    public string UserName { get; set; }
    [Display(Name = "ایمیل")]
    [Required]
    [MaxLength(50, ErrorMessage = "ایمیل نمی تواند بزرگ تر از 50 کاراکتر باشد")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Display(Name = "کلمه عبور")]
    [Required]
    [MaxLength(50, ErrorMessage = "کلمه عبور نمی تواند بزرگ تر از 50 کاراکتر باشد")]
    public string Password { get; set; }
    [Display(Name = "تاریخ ثبت نام")]
    public DateTime CreateDate { get; set; }

    public ICollection<Post> Posts { get; set; }
}