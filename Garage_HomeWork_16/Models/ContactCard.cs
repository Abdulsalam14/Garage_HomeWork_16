namespace Garage_HomeWork_16.Models
{
    public class ContactCard
    {
        public int Id { get; set; }
        public string ?Title { get; set; }
        public string? Fullname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IconClassName { get; set; }
        public int ContactId { get; set; }
        public Contact? Contact { get; set; }
    }
}
