using System.ComponentModel.DataAnnotations;
namespace MyBlog.Web.Models.Comments;
public class Comment
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "نام کاربر")]
    [Required]
    [MaxLength(50, ErrorMessage = "نام کاربری نمی تواند بزرگ تر از 50 کاراکتر باشد")]
    [MinLength(3,ErrorMessage = "کمتر از 3 کاراکتر نمیشود")]
    [DataType(DataType.Text)]
    public string UserName { get; set; }
    [Display(Name = "متن")]
    [Required]
    [MaxLength(500,ErrorMessage = "نمی توان بیشتر از 500 کاراکتر وارد کرد")]
    [MinLength(5, ErrorMessage = "کمتر از 5 کاراکتر نمیشود")]
    [DataType(DataType.Text)]
    public string Description { get; set; }
    [Display(Name = "تاریخ ثبت")]
    public DateTime CreateDate { get; set; }
    public ICollection<PostComments> PostComments { get; set; }
}