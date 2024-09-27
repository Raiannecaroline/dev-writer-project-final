using DevWriterAPI.Data;
using DevWriterAPI.Models.Domain;
using DevWriterAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DevWriterAPI.Repositories.Implementation
{
    public class CategoryRepositoy : ICategoryRepository
    {
        /// <summary> Propriedade para acessar o banco de dados </summary>
        private readonly BlogDbContext dbContext;

        /// <summary> Construtor da classe </summary>
        public CategoryRepositoy(BlogDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        /// <summary> Método para criar uma categoria </summary>
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }

        /// <summary> Método para deletar uma categoria </summary>
        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (existCategory is null)
            {
                return null;
            }

            dbContext.Categories.Remove(existCategory);
            await dbContext.SaveChangesAsync();
            return existCategory;
        }

        /// <summary> Método para buscar todas as categorias </summary>
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }


        /// <summary> Método para buscar uma categoria pelo ID </summary>
        public async Task<Category?> GetById(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }


        /// <summary> Método para atualizar/editar (update) uma categoria </summary>
        public async Task<Category?> UpdateAsync(Category category)
        {
            var existCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (existCategory != null)
            {
                dbContext.Entry(existCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return existCategory;
            }

            return null;

        }
    }
}
