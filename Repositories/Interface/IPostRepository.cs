using DevWriterAPI.Models.Domain;

namespace DevWriterAPI.Repositories.Interface
{
    public interface IPostRepository
    {
        /// <summary> Método para criar um novo Post </summary>
        Task<Post> CreateAsync(Post post);

        /// <summary> Método para listar todos os Posts </summary>
        Task<IEnumerable<Post>> GetAllAsync();
    }
}
