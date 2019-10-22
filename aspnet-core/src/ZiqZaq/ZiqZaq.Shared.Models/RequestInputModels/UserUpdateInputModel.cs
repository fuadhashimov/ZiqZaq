using System.ComponentModel.DataAnnotations;

namespace ZiqZaq.Shared.Models.RequestInputModels
{
    public class UserUpdateInputModel
    {
        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
