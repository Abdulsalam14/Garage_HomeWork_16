namespace Garage_HomeWork_16.Models
{
    public class FeaturedWorkComponent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<FeaturedWorkComponentPhoto> FeaturedWorkComponentPhotos { get; set; }
    }
}
