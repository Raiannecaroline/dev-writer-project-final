using DevWriterAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevWriterAPI.Data
{
    public class BlogDbContext : DbContext
    {
        /// <summary> Construtor da classe </summary>
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary> Propriedades da classe </summary>
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
    }
}
