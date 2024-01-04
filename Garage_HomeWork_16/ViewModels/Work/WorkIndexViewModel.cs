using Garage_HomeWork_16.Models;

namespace Garage_HomeWork_16.ViewModels.Work
{
    public class WorkIndexViewModel
    {
        public List<Category> Categories { get; set; }
        public List<CategoryComponent> CategoryComponents { get; set; }

        public FeaturedWorkComponent FeaturedWorkComponent { get; set; }
    }
}
