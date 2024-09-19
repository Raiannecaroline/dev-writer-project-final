using DevWriterAPI.Data;
using DevWriterAPI.Models.Domain;
using DevWriterAPI.Repositories.Interface;

namespace DevWriterAPI.Repositories.Implementation
{
    public class CategoryRepositoy : ICategoryRepository
    {

        private readonly BlogDbContext dbContext;

        public CategoryRepositoy(BlogDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }
    }
}
