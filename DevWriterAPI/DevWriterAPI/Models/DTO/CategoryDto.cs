namespace DevWriterAPI.Models.DTO
{

    /// <summary> DTO para a categoria </summary>
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}
