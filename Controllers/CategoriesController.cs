using DevWriterAPI.Data;
using DevWriterAPI.Models.Domain;
using DevWriterAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevWriterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly BlogDbContext dbContext;

        public CategoriesController(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request) 
        {
            /// <summary> Mapeando o DTO para o Domain (Model) </summary>
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            /// <summary> Mapeando o Domain (Model) para o DTO </summary>
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            /// <summary> Retornando o status 200 (OK) </summary>
            return Ok();
        }
    }
}
