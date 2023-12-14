namespace Garage_HomeWork_16.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? Description { get; set; }
        public List <ContactCard>? ContactCards{ get; set; }

    }
}
