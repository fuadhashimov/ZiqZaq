using System.ComponentModel.DataAnnotations;

namespace ZiqZaq.Shared.Models.Attributes
{
    internal class PositiveNumberAttribute : ValidationAttribute
    {
        private RangeAttribute WrappedAttribute { get; }

        public PositiveNumberAttribute(int minimum = 1, int maximum = int.MaxValue)
        {
            WrappedAttribute = new RangeAttribute(minimum, maximum);
        }

        public override bool IsValid(object value)
        {
            return WrappedAttribute.IsValid(value);
        }
    }
}