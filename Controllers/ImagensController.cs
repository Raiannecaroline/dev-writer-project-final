using DevWriterAPI.Models.Domain;
using DevWriterAPI.Models.DTO;
using DevWriterAPI.Repositories.Implementation;
using DevWriterAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevWriterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagensController : ControllerBase
    {
        private readonly IImagemRepository imagemRepository;

        public ImagensController(IImagemRepository imagemRepository)
        {
            this.imagemRepository = imagemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImagem([FromForm] IFormFile file,
            [FromForm] string fileName, [FromForm] string title)
        {
            /// <summary> Validação do Arquivo </summary>
            ValidateFileUpload(file);

            if (ModelState.IsValid)
            {
                /// <summary> Criação da Imagem </summary>
                var imagem = new Imagem
                {
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    FileName = fileName,
                    Title = title,
                    DateCreated = DateTime.Now

                };

                /// <summary> Upload da Imagem para o servidor </summary>
                imagem = await imagemRepository.Upload(file, imagem);

                var response = new ImagemDto
                {
                    Id = imagem.Id,
                    Title = imagem.Title,
                    DateCreated = imagem.DateCreated,
                    FileExtension = imagem.FileExtension,
                    FileName = imagem.FileName,
                    Url = imagem.Url
                };

                /// <summary> Retorno da Imagem </summary>
                return Ok(imagem);
            }

            return BadRequest(ModelState);
        }

        /// <summary> Upload da Imagem para o servidor </summary>
        private void ValidateFileUpload(IFormFile file)
        {
            /// <summary> Validação do Arquivo </summary>
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Extensão de arquivo inválida.");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "Tamanho máximo permitido de 10MB.");
            }
        }
    }
}
