using System.ComponentModel.DataAnnotations;

namespace Application.DtoModels
{
    public class ContactDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }
    }
}