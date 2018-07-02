using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lykke.Common.Validation.PasswordHash
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PasswordHashAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var passwordHash = (string) value;

            if (string.IsNullOrWhiteSpace(passwordHash))
                return new ValidationResult("Value is null or empty.");

            return Regex.IsMatch(passwordHash, "^[A-Fa-f0-9]{64}$")
                ? ValidationResult.Success
                : new ValidationResult("Value must be valid SHA-256 hash.");
        }
    }
}