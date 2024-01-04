using System.ComponentModel.DataAnnotations;

namespace Garage_HomeWork_16.Areas.Admin.ViewModels.FeaturedWorkComponent
{
    public class FeaturedWorkComponentCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }

    }
}
