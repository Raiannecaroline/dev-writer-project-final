using DevWriterAPI.Data;
using DevWriterAPI.Models.Domain;
using DevWriterAPI.Models.DTO;
using DevWriterAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevWriterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        /// <summary> Método para criar uma categoria </summary>
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request) 
        {
            /// <summary> Mapeando o DTO para o Domain (Model) </summary>
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await categoryRepository.CreateAsync(category);
             
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


        /// <summary> Método para buscar todas as categorias </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllAsync();

            var response = new List<CategoryDto>();
            foreach (var category in categories)
            {
                /// <summary> Mapeando o Domain (Model) para o DTO </summary>
                response .Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }

            /// <summary> Retornando o status 200 (OK) </summary>
            return Ok(response);

        }
    }
}
