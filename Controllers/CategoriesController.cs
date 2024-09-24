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

        /// <summary> Construtor da classe </summary>
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        /// <summary> Método para criar uma categoria </summary>
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request) 
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

        [HttpGet]
        [Route("{id:Guid}")]

        /// <summary> Método para buscar uma categoria por ID </summary>
        public async Task<IActionResult> GetCategoriesById([FromRoute] Guid id)
        {
            var existCategories = await categoryRepository.GetById(id);

            if (existCategories == null)
            {
                /// <summary> Retornando o status 404 (Not Found) </summary>
                return NotFound();
            }

            /// <summary> Mapeando o Domain (Model) para o DTO </summary>
            var respose = new CategoryDto
            {
                Id = existCategories.Id,
                Name = existCategories.Name,
                UrlHandle = existCategories.UrlHandle
            };

            /// <summary> Retornando o status 200 (OK) </summary>
            return Ok(respose);
        }

        /// <summary> Método para alterar (update) em uma categoria </summary>
        [HttpPut]
        [Route("{id:Guid}")]

        /// <summary> Método para atualizar uma categoria </summary>
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCategoryRequestDto request)
        {
            /// <summary> Buscando a categoria pelo ID </summary>
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            category = await categoryRepository.UpdateAsync(category);
            
            if (category == null)
            {
                /// <summary> Retornando o status 404 (Not Found) </summary>
                return NotFound();
            }

            /// <summary> Mapeando o Domain (Model) para o DTO </summary>
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            /// <summary> Retornando o status 200 (OK) </summary>
            return Ok(response);
            
        }

        /// <summary> Método para deletar uma categoria </summary>
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategorie([FromRoute] Guid id)
        {
           var categoryDelete = await categoryRepository.DeleteAsync(id);

            if (categoryDelete == null)
              {
                /// <summary> Retornando o status 404 (Not Found) </summary>
                return NotFound();
              }

            /// <summary> Mapeando o Domain (Model) para o DTO </summary>
            var response = new CategoryDto
            {
                Id = categoryDelete.Id,
                Name = categoryDelete.Name,
                UrlHandle = categoryDelete.UrlHandle
            };

            /// <summary> Retornando o status 200 (OK) </summary>
            return Ok(response);
        }
    }
}