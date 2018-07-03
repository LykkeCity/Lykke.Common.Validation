using FluentValidation;
using Lykke.Common.Validation.PasswordHash.Fluent;
using Lykke.Common.Validation.Tests.PasswordHash.TestModels;

namespace Lykke.Common.Validation.Tests.PasswordHash.Fluent
{
    /// <summary>
    ///     Example of using fluent validator
    /// </summary>
    internal class PasswordHashTestValidator : AbstractValidator<PasswordHashTestModel> 
    {
        public PasswordHashTestValidator()
        {
            RuleFor(model => model.PasswordHash).SetValidator(new PasswordHashValidator());
        }
    }
}
