using Lykke.Common.Validation.NoSpecialCharacters.Base;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData;
using Xunit;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters.Base
{
    public class NoSpecialCharactersBaseValidatorTests
    {
        private readonly NoSpecialCharactersBaseValidator _baseValidator;

        public NoSpecialCharactersBaseValidatorTests()
        {
            _baseValidator = new NoSpecialCharactersBaseValidator();
        }

        [Theory]
        [ClassData(typeof(WithoutSpecialCharacters))]
        public void IsValid_WithoutSpecialCharacters_ReturnTrue(string input)
        {
            Assert.True(_baseValidator.IsValid(input));
        }

        [Theory]
        [ClassData(typeof(WithSpecialCharacters))]
        public void IsValid_WithSpecialCharacters_ReturnFalse(string input)
        {
            Assert.False(_baseValidator.IsValid(input));
        }        
        
        [Theory]
        [ClassData(typeof(NullOrEmptyStringTestData))]
        public void IsValid_NullOrEmpty_ReturnFalse(string input)
        {
            Assert.False(_baseValidator.IsValid(input));
        }
    }
}