using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Lykke.Common.Validation.FloatingPointNumber.Base;

namespace Lykke.Common.Validation.FloatingPointNumber.Attribute
{
    /// <summary>
    ///     Validates string is a floating point number.
    ///     Use only on <see cref="string" />.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FloatingPointNumberAttribute : ValidationAttribute
    {
        private readonly string _defaultErrorMessage = "{0} must be a floating point number.";

        private readonly FloatingPointNumberBaseValidator _baseValidator;

        public FloatingPointNumberAttribute()
        {
            _baseValidator = new FloatingPointNumberBaseValidator();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var displayName = validationContext.DisplayName;

            var errorResult = new ValidationResult(FormatErrorMessage(displayName));

            return _baseValidator.IsValid(value as string)
                ? ValidationResult.Success
                : errorResult;
        }

        public override string FormatErrorMessage(string name)
        {
            var errorMessage = string.IsNullOrWhiteSpace(ErrorMessage) ? _defaultErrorMessage : ErrorMessage;

            return string.Format(CultureInfo.CurrentCulture, errorMessage, name);
        }
    }
}