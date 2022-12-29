using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Client.ViewModels.Authentication
{
    public class RegisterUpdateViewModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
    }
}
