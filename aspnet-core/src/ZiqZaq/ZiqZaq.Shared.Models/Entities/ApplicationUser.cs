using System;
using Microsoft.AspNetCore.Identity;

namespace ZiqZaq.Shared.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsActive { get; set; }
        public byte Gender { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}