using DevWriterAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevWriterAPI.Models.Domain;
using DevWriterAPI.Repositories.Interface;
using DevWriterAPI.Repositories.Implementation;

namespace DevWriterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository postRepository;
        private readonly ICategoryRepository categoryRepository;

        public PostsController(IPostRepository postRepository,
            ICategoryRepository categoryRepository)
        {
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
        }


        /// <summary> Criando um novo Post (Publicação) </summary>
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequestDto request)
        {
            /// <summary> Validação do modelo </summary>
            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                UlHandler = request.UlHandler,
                PublishAt = request.PublishAt,
                AuthorAt = request.AuthorAt,
                IsVisible = request.IsVisible,
                Categories = new List<Category>()
            };

            foreach (var categoryGuid in request.Categories)
            {
                var existingCategory = await categoryRepository.GetById(categoryGuid);
                if (existingCategory is not null)
                {
                    post.Categories.Add(existingCategory);
                }
            }

            /// <summary> Salvando o Post no banco de dados </summary>
            post = await postRepository.CreateAsync(post);

            /// <summary> Resposta da requisição </summary>
            var response = new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Description = post.Description,
                ImageUrl = post.ImageUrl,
                UlHandler = post.UlHandler,
                PublishAt = post.PublishAt,
                AuthorAt = post.AuthorAt,
                IsVisible = post.IsVisible,
                Categories = post.Categories.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            /// <summary> Retornando a resposta Ok(200) </summary>
            return Ok(response);
        }

        /// <summary> Listando todos os Posts (Publicações) </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await postRepository.GetAllAsync();

            /// <summary> Resposta da requisição </summary>
            var response = new List<PostDto>();

            /// <summary> Mapeando os Posts para o DTO </summary>
            foreach (var post in posts)
            {
                response.Add(new PostDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Description = post.Description,
                    ImageUrl = post.ImageUrl,
                    UlHandler = post.UlHandler,
                    PublishAt = post.PublishAt,
                    AuthorAt = post.AuthorAt,
                    IsVisible = post.IsVisible,
                    Categories = post.Categories.Select(x => new CategoryDto
                     {
                         Id = x.Id,
                         Name = x.Name,
                         UrlHandle = x.UrlHandle
                     }).ToList()
                });
            }

            /// <summary> Retornando a resposta Ok(200) </summary>
            return Ok(response);
        }
    }
}
