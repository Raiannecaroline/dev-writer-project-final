using DevWriterAPI.Data;
using DevWriterAPI.Models.Domain;
using DevWriterAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DevWriterAPI.Repositories.Implementation
{
    public class ImagemRepository : IImagemRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BlogDbContext dbContext;

        public ImagemRepository(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            BlogDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Imagem> Upload(IFormFile file, Imagem imagem)
        {
            /// <summary> Salva a imagem no servidor </summary>
            var pathLocal = Path.Combine(webHostEnvironment.WebRootPath, "Imagens", $"{imagem.FileName}{imagem.FileExtension}");
            using var stream = new FileStream(pathLocal, FileMode.Create);
            await file.CopyToAsync(stream);

            /// <summary> Atualiza a URL da imagem </summary>
            var httpRequestImagem = httpContextAccessor.HttpContext.Request;
            var urlBasePath = $"{httpRequestImagem.Scheme}://{httpRequestImagem.Host}{httpRequestImagem.PathBase}/Imagens/{imagem.FileName}{imagem.FileExtension}";

            /// <summary> Atualiza a URL da imagem </summary>
            imagem.Url = urlBasePath;

            /// <summary> Salva a imagem no banco de dados </summary>
            await dbContext.Imagens.AddAsync(imagem);
            await dbContext.SaveChangesAsync();

            /// <summary> Retorna a imagem </summary>
            return imagem;

        }
    }
}
