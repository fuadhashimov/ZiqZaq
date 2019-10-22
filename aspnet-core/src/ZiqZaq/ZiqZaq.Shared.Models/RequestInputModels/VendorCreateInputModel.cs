using System.ComponentModel.DataAnnotations;
using ZiqZaq.Shared.Models.Attributes;

namespace ZiqZaq.Shared.Models.RequestInputModels
{
    public class VendorCreateInputModel
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
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(256)]
        public string AgencyName { get; set; }

        [Required]
        [MaxLength(256)]
        public string AgencyEmail { get; set; }

        [MaxLength(32)]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [MaxLength(32)]
        [EmptyAllowedPhone]
        public string HomePhone { get; set; }

        [Url]
        public string Website { get; set; }

        public string FacebookAddress { get; set; }

        public string InstagramAddress { get; set; }

        public string TwitterAddress { get; set; }
    }
}