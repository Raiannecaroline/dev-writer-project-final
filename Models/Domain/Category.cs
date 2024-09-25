namespace DevWriterAPI.Models.Domain
{
    /// <summary> Modelagem da Classe de categoria </summary>
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
