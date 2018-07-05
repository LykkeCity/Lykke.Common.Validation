using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Lykke.Common.Validation.NoSpecialCharacters.Base;

namespace Lykke.Common.Validation.NoSpecialCharacters.Attribute
{
    /// <summary>
    ///     Validates string does not contain special characters.
    ///     Use only on <see cref="string" />.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NoSpecialCharactersAttribute : ValidationAttribute
    {
        private readonly string _defaultErrorMessage = "{0} must not contain special characters.";

        private readonly NoSpecialCharactersBaseValidator _baseValidator;

        public NoSpecialCharactersAttribute()
        {
            _baseValidator = new NoSpecialCharactersBaseValidator();
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