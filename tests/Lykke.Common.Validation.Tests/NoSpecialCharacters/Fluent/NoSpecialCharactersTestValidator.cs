using FluentValidation;
using Lykke.Common.Validation.NoSpecialCharacters.Fluent;
using Lykke.Common.Validation.Tests.NoSpecialCharacters.TestModels;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters.Fluent
{
    /// <summary>
    ///     Example of using fluent validator
    /// </summary>
    internal class NoSpecialCharactersTestValidator : AbstractValidator<NoSpecialCharactersTestModel>
    {
        public NoSpecialCharactersTestValidator()
        {
            RuleFor(model => model.Input).SetValidator(new NoSpecialCharactersValidator());
        }
    }
}