using DevWriterAPI.Models.Domain;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DevWriterAPI.Repositories.Interface
{
    public interface ICategoryRepository
    {
        /// <summary> Método para criar uma categoria </summary>
        Task<Category> CreateAsync(Category category);

        /// <summary> Método para buscar todas as categorias </summary>
        Task<IEnumerable<Category>> GetAllAsync();

        /// <summary> Método para buscar uma categoria por ID </summary>
        Task<Category?> GetById(Guid id);

        /// <summary> Método para atualizar uma categoria </summary>
        Task<Category?> UpdateAsync(Category category);

        /// <summary> Método para deletar uma categoria </summary>
        Task<Category?> DeleteAsync(Guid id);
    }
}
