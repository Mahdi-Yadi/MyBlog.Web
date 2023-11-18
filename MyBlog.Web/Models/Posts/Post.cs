using System.ComponentModel.DataAnnotations;
using MyBlog.Web.Models.Account;
using MyBlog.Web.Models.Categories;
using MyBlog.Web.Models.Comments;
namespace MyBlog.Web.Models.Posts;
public class Post
{
    [Key]
    public int Id { get; set; }
    public int CategoryId { get; set; }
    [Display(Name = "عنوان خبر")]
    [Required]
    [MaxLength(350, ErrorMessage = "نام کاربری نمی تواند بزرگ تر از 50 کاراکتر باشد")]
    public string Title { get; set; }
    [Display(Name = "متن")]
    [Required]
    public string Description { get; set; }
    [Display(Name = "تصویر خبر")]
    [MaxLength(60)]
    public string ImageName { get; set; }
    [Display(Name = "تاریخ ثبت")]
    public DateTime CreateDate { get; set; }
    public DateTime Update { get; set; }
    [Display(Name = "بازدید")]
    public long Visited { get; set; }
    public bool IsSpecial { get; set; }
    public User User { get; set; }
    public ICollection<PostComments> PostComments { get; set; }
    public Category Category { get; set; }
}