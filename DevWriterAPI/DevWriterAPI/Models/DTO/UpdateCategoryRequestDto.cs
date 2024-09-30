namespace DevWriterAPI.Models.DTO
{

    /// <summary> DTO para atualizar a categoria </summary>
    public class UpdateCategoryRequestDto
    {
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}
