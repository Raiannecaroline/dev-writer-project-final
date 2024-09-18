using DevWriterAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevWriterAPI.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
