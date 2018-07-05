using FluentValidation.Validators;
using Lykke.Common.Validation.NoSpecialCharacters.Base;

namespace Lykke.Common.Validation.NoSpecialCharacters.Fluent
{
    /// <summary>
    ///     Validates string does not contain special characters.
    ///     Use only on <see cref="string" />.
    /// </summary>
    public class NoSpecialCharactersValidator : PropertyValidator
    {
        private readonly NoSpecialCharactersBaseValidator _baseValidator;

        public NoSpecialCharactersValidator() : base("{PropertyName} must not contain special characters.")
        {
            _baseValidator = new NoSpecialCharactersBaseValidator();
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return _baseValidator.IsValid(context.PropertyValue as string);
        }
    }
}