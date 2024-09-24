using DevWriterAPI.Models.Domain;

namespace DevWriterAPI.Repositories.Interface
{
    public interface IPostRepository
    {
        /// <summary> Método para criar um novo Post </summary>
        Task<Post> CreateAsync(Post post);
    }
}
