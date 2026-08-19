using Microsoft.EntityFrameworkCore;
using MiniFacebook.Models;

namespace MiniFacebook.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        DbSet<Post> Posts { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Comment> Comments { get; set; }

    }
}
