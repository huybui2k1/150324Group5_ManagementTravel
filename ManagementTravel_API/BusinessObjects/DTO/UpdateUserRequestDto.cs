using System.ComponentModel.DataAnnotations;

namespace ManagementTravel_API.BusinessObjects.DTO
{
    public class UpdateUserRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "User Name has to be a maximum of 100 characters")]
        public string UserName { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
    }
}
