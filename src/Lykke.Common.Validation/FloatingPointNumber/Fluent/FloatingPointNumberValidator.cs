using FluentValidation.Validators;
using Lykke.Common.Validation.FloatingPointNumber.Base;

namespace Lykke.Common.Validation.FloatingPointNumber.Fluent
{
    /// <summary>
    ///     Validates string is a floating point number.
    ///     Use only on <see cref="string" />.
    /// </summary>
    public class FloatingPointNumberValidator : PropertyValidator
    {
        private readonly FloatingPointNumberBaseValidator _baseValidator;

        public FloatingPointNumberValidator() : base("{PropertyName} must be a floating point number.")
        {
            _baseValidator = new FloatingPointNumberBaseValidator();
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return _baseValidator.IsValid(context.PropertyValue as string);
        }
    }
}