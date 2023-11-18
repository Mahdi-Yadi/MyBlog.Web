namespace MyBlog.Web.ViewModels.Posts;
public class PostForAdminViewModel
{
    public int PostId { get; set; }
    public string PostTitle { get; set; }
    public string ImageName { get; set; }
    public bool IsSpecial { get; set; }
    public DateTime CreateDate { get; set; }
}