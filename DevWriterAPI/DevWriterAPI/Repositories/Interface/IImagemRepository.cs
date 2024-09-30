using DevWriterAPI.Models.Domain;

namespace DevWriterAPI.Repositories.Interface
{
    public interface IImagemRepository
    {
        /// <summary> Upload da Imagem para o servidor </summary>
        Task<Imagem> Upload(IFormFile file, Imagem imagem);

        /// <summary> Retorna todas as imagens </summary>
        Task<IEnumerable<Imagem>> GetAll();
    }
}
