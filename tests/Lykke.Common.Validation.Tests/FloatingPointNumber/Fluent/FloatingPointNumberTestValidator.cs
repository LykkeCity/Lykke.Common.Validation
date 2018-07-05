using FluentValidation;
using Lykke.Common.Validation.FloatingPointNumber.Fluent;
using Lykke.Common.Validation.Tests.FloatingPointNumber.TestModels;

namespace Lykke.Common.Validation.Tests.FloatingPointNumber.Fluent
{
    /// <summary>
    ///     Example of using fluent validator
    /// </summary>
    internal class FloatingPointNumberTestValidator : AbstractValidator<FloatingPointNumberTestModel>
    {
        public FloatingPointNumberTestValidator()
        {
            RuleFor(model => model.Input).SetValidator(new FloatingPointNumberValidator());
        }
    }
}