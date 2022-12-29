using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Client.ViewModels.Authentication
{
    public class PasswordUpdateVIewModel
    {
        [Required]
        public string? OlderPassword { get; set; }
        [Required]
        public string? NewPassword { get; set; }
    }
}
