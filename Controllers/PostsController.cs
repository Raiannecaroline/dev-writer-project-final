using DevWriterAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevWriterAPI.Models.Domain;
using DevWriterAPI.Repositories.Interface;

namespace DevWriterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository postRepository;

        public PostsController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
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
                IsVisible = request.IsVisible
            };

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
                IsVisible = post.IsVisible
            };

            /// <summary> Retornando a resposta Ok(200) </summary>
            return Ok(response);
        }
    }
}
