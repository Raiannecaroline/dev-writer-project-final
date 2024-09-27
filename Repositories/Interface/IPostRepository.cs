using DevWriterAPI.Models.Domain;

namespace DevWriterAPI.Repositories.Interface
{
    public interface IPostRepository
    {
        /// <summary> Método para criar um novo Post </summary>
        Task<Post> CreateAsync(Post post);

        /// <summary> Método para listar todos os Posts </summary>
        Task<IEnumerable<Post>> GetAllAsync();

        /// <summary> Método para buscar um Post pelo ID </summary>
        Task<Post?> GetByIdAsync(Guid id);
    }
}
