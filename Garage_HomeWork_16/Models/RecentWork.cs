using System.ComponentModel.DataAnnotations;

namespace Garage_HomeWork_16.Models
{
    public class RecentWork
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad mutleq yazilmalidir"), MinLength(3, ErrorMessage = "Uzunluq en az 3 olmalidir")]
        public string Title { get; set; }
        public string Text { get; set; }
        public string? ImagePath { get; set; }
    }
}
