using Microsoft.EntityFrameworkCore;
using MyBlog.Web.Models.Account;
using MyBlog.Web.Models.Categories;
using MyBlog.Web.Models.Comments;
using MyBlog.Web.Models.Posts;
namespace MyBlog.Web.Data;
public class MyBlogContext : DbContext
{
    public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
    {
        
    }

    #region User
    public DbSet<User> Users { get; set; }
    #endregion

    #region Categories
    public DbSet<Category> Categories { get; set; }
    #endregion

    #region Post Comments
    public DbSet<PostComments> PostComments { get; set; }
    public DbSet<Comment> Comments { get; set; }
    #endregion

    #region Posts
    public DbSet<Post> Posts { get; set; }
    #endregion

    #region on Model Creating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }
    #endregion
}