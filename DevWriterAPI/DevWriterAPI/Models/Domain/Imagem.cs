namespace DevWriterAPI.Models.Domain
{
    public class Imagem
    {
        /// <summary> Propriedades da classe </summary>
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
