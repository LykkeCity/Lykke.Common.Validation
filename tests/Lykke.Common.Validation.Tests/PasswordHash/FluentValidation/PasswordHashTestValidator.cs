using FluentValidation;
using Lykke.Common.Validation.PasswordHash;
using Lykke.Common.Validation.Tests.PasswordHash.TestModels;

namespace Lykke.Common.Validation.Tests.PasswordHash.FluentValidation
{
    internal class PasswordHashTestValidator : AbstractValidator<PasswordHashTestModel> 
    {
        public PasswordHashTestValidator()
        {
            RuleFor(model => model.PasswordHash).SetValidator(new PasswordHashFluentValidator());
        }
    }
}
