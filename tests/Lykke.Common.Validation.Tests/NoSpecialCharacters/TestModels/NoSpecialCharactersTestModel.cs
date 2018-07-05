using Lykke.Common.Validation.NoSpecialCharacters.Attribute;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters.TestModels
{
    internal class NoSpecialCharactersTestModel
    {
        [NoSpecialCharacters]
        public string Input { get; set; }
    }
}
