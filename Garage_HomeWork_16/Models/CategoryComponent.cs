namespace Garage_HomeWork_16.Models
{
    public class CategoryComponent
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }
        public List<Category> Categories { get; set; }
    }
}
