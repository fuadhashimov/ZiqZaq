using System;

namespace ZiqZaq.Shared.Models.RequestOutputModels
{
    public class UserRegisterOutputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
    }
}