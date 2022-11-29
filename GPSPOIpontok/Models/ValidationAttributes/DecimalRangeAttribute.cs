using System.ComponentModel.DataAnnotations;

namespace GPSPOIpontok.Models.ValidationAttributes
{
    public sealed class DecimalRangeAttribute : ValidationAttribute
    {
        private readonly double min, max;

        public DecimalRangeAttribute(double min,double max)
        {
            this.min = min;
            this.max = max;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || !(value is double))
            {
                return ValidationResult.Success;
            }

            // Compare values
            if ((double)value >= min && (double)value <= max)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
