using System.ComponentModel.DataAnnotations;

namespace Garage_HomeWork_16.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Ad mutleq yazilmalidir"),MinLength(3,ErrorMessage ="Uzunluq en az 3 olmalidir")]
        public string? Title { get; set; }

        public List<CategoryComponent>? CategoryComponents { get; set; }
    }
}
