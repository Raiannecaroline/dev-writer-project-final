namespace DevWriterAPI.Models.DTO
{
    public class UpdatePostRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string UlHandler { get; set; }
        public DateTime PublishAt { get; set; }
        public string AuthorAt { get; set; }
        public bool IsVisible { get; set; }

        public List<Guid> Categories { get; set; } = new List<Guid>();
    }
}
