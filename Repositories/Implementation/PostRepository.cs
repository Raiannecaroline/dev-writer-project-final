using DevWriterAPI.Data;
using DevWriterAPI.Models.Domain;
using DevWriterAPI.Repositories.Interface;

namespace DevWriterAPI.Repositories.Implementation
{
    public class PostRepository : IPostRepository
    {
        /// <summary> Contexto do banco de dados </summary>
        private readonly BlogDbContext dbContext;


        /// <summary> Construtor </summary>
        public PostRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        /// <summary> Método para criar um novo Post </summary>
        public async Task<Post> CreateAsync(Post post)
        {
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return post;
        }
    }
}
