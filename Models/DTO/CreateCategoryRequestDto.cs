namespace DevWriterAPI.Models.DTO
{
    /// <summary> DTO para a requisição de criação de categoria </summary>
    public class CreateCategoryRequestDto
    {
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}
