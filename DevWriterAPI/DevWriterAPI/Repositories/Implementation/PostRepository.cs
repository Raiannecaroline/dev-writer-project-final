using DevWriterAPI.Data;
using DevWriterAPI.Models.Domain;
using DevWriterAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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

        /// <summary> Método para listar todos os Posts </summary>
        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await dbContext.Posts.Include(x => x.Categories).ToListAsync();
        }

        /// <summary> Método para buscar um Post pelo ID </summary>
        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await dbContext.Posts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post?> UpdateAsync(Post post)
        {
            var existingPost = await dbContext.Posts.Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == post.Id);

            if (existingPost == null)
            {
                return null;
            }

            /// <summary> Atualizando as propriedades do Post </summary>
            dbContext.Entry(existingPost).CurrentValues.SetValues(post);

            /// <summary> Atualizando as categorias do Post </summary>
            existingPost.Categories = post.Categories;

            /// <summary> Salvando as alterações no banco de dados </summary>
            await dbContext.SaveChangesAsync();

            /// <summary> Retornando o Post atualizado </summary>
            return post;
        }

        /// <summary> Método para deletar um Post </summary>
        public async Task<Post?> DeleteAsync(Guid id)
        {
            /// <summary> Buscando o Post pelo ID </summary>
            var existingPost = await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);

            /// <summary> Verificando se o Post existe </summary>
            if (existingPost != null)
            {
                /// <summary> Removendo o Post </summary>
                dbContext.Posts.Remove(existingPost);
                await dbContext.SaveChangesAsync();
                return existingPost;
            }

            /// <summary> Retornando nulo caso o Post não exista </summary>
            return null;
        }

        public async Task<Post?> GetByUrlAsync(string urlHandle)
        {
            return await dbContext.Posts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.ImageUrl == urlHandle);
        }
    }
}
