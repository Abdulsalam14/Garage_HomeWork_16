using System.ComponentModel.DataAnnotations;

namespace Garage_HomeWork_16.Areas.Admin.Views.FeaturedWorkComponent.FeaturedWorkComponentPhoto
{
    public class FeaturedWorkComponentPhotoUpdateVM
    {
        public int Id { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
