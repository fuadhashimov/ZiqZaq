using System;
using System.ComponentModel.DataAnnotations;
using ZiqZaq.Shared.Models.Attributes;

namespace ZiqZaq.Shared.Models.RequestInputModels
{
    public class UserRegisterInputModel
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Surname { get; set; }

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

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DateOfBirth(MinAge = 16, MaxAge = 130)]
        public DateTime Birthday { get; set; }

        [Required]
        public byte Gender { get; set; }
    }
}
