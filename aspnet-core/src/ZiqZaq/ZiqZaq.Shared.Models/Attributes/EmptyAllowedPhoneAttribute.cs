using System;
using System.ComponentModel.DataAnnotations;

namespace ZiqZaq.Shared.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class EmptyAllowedPhoneAttribute : ValidationAttribute
    {
        private readonly PhoneAttribute _wrappedAttribute = new PhoneAttribute();

        public override bool IsValid(object value)
        {
            return (string)value == string.Empty || _wrappedAttribute.IsValid(value);
        }
    }
}
