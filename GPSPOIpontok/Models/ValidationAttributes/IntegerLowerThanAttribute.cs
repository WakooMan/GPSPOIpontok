using System.ComponentModel.DataAnnotations;

namespace GPSPOIpontok.Models.ValidationAttributes
{
    public sealed class IntegerLowerThanAttribute : ValidationAttribute
    {
        private readonly string testedPropertyName;
        private readonly bool allowEqualIntegers;

        public IntegerLowerThanAttribute(string testedPropertyName, bool allowEqualIntegers = false)
        {
            this.testedPropertyName = testedPropertyName;
            this.allowEqualIntegers = allowEqualIntegers;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(this.testedPropertyName);
            if (propertyTestedInfo == null)
            {
                return new ValidationResult(string.Format("unknown property {0}", this.testedPropertyName));
            }

            var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);

            if (value == null || !(value is int))
            {
                return ValidationResult.Success;
            }

            if (propertyTestedValue == null || !(propertyTestedValue is int))
            {
                return ValidationResult.Success;
            }

            // Compare values
            if ((int)value <= (int)propertyTestedValue)
            {
                if (this.allowEqualIntegers && (int)value == (int)propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
                else if ((int)value < (int)propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
