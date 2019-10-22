using System.ComponentModel.DataAnnotations;

namespace ZiqZaq.Shared.Models.RequestInputModels
{
    public class UserLoginInputModel
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}