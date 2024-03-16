using System.ComponentModel.DataAnnotations;

namespace ManagementTravel_MVC.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui long nhap ten.")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Vui long nhap Email.")]
        [EmailAddress(ErrorMessage = "Email khong hop le.")]
        public string Email { get; set; }
    }
}
