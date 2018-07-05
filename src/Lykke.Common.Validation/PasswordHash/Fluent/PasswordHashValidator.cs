using FluentValidation.Validators;
using Lykke.Common.Validation.PasswordHash.Base;

namespace Lykke.Common.Validation.PasswordHash.Fluent
{
    /// <summary>
    ///     Validates string is a valid SHA-256 hash.
    ///     Use only on <see cref="string" />.
    /// </summary>
    public class PasswordHashValidator : PropertyValidator
    {
        private readonly PasswordHashBaseValidator _passwordHashBaseValidator;

        public PasswordHashValidator() : base("{PropertyName} must be valid SHA-256 hash.")
        {
            _passwordHashBaseValidator = new PasswordHashBaseValidator();
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return _passwordHashBaseValidator.IsValid(context.PropertyValue as string);
        }
    }
}