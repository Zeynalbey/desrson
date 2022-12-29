using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Client.ViewModels.Authentication
{
    public class AddressUpdateViewModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
