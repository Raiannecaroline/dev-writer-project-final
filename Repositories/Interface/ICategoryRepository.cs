using DevWriterAPI.Models.Domain;

namespace DevWriterAPI.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();
    }
}
