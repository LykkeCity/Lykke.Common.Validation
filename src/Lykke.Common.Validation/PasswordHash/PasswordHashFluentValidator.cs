using System.Text.RegularExpressions;
using FluentValidation.Validators;

namespace Lykke.Common.Validation.PasswordHash
{
    public class PasswordHashFluentValidator : PropertyValidator
    {
        public PasswordHashFluentValidator() : base("{PropertyName} must have valid SHA-256 hash format.")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var passwordHash = (string) context.PropertyValue;

            return !string.IsNullOrWhiteSpace(passwordHash) && Regex.IsMatch(passwordHash, "^[A-Fa-f0-9]{64}$");
        }
    }
}