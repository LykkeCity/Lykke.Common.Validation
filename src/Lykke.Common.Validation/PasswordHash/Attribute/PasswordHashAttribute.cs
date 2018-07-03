using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Lykke.Common.Validation.PasswordHash.Base;

namespace Lykke.Common.Validation.PasswordHash.Attribute
{
    /// <summary>
    ///     Validates string is a valid SHA-256 hash.
    ///     Use only on <see cref="string" />.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PasswordHashAttribute : ValidationAttribute
    {
        private readonly string _defaultErrorMessage = "{0} must be valid SHA-256 hash.";
        private readonly PasswordHashBaseValidator _passwordHashBaseValidator;

        public PasswordHashAttribute()
        {
            _passwordHashBaseValidator = new PasswordHashBaseValidator();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var displayName = validationContext.DisplayName;

            var errorResult = new ValidationResult(FormatErrorMessage(displayName));

            if (!(value is string passwordHash) || string.IsNullOrWhiteSpace(passwordHash))
                return errorResult;

            return _passwordHashBaseValidator.IsValid(passwordHash)
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