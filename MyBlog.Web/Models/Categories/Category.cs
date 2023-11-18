using System.ComponentModel.DataAnnotations;
using MyBlog.Web.Models.Posts;
namespace MyBlog.Web.Models.Categories;
public class Category
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "نام گروه")]
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
    public ICollection<Post> Posts { get; set; }
}