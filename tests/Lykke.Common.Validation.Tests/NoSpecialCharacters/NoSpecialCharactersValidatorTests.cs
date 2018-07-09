using System.Linq;
using Lykke.Common.Validation.NoSpecialCharacters;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData;
using Xunit;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters
{
    public class NoSpecialCharactersValidatorTests
    {
        private readonly NoSpecialCharactersValidator _validator;

        public NoSpecialCharactersValidatorTests()
        {
            _validator = new NoSpecialCharactersValidator();
        }

        [Theory]
        [ClassData(typeof(WithoutSpecialCharactersTestData))]
        public void Validate_WithoutSpecialCharacters_ReturnTrue(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }

        [Theory]
        [ClassData(typeof(WithSpecialCharactersTestData))]
        public void Validate_WithSpecialCharacters_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(NoSpecialCharactersErrorCode.ContainsSpecialCharacters, result.ErrorCodes.First());
        }

        [Theory]
        [ClassData(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(NoSpecialCharactersErrorCode.NullOrEmpty, result.ErrorCodes.First());
        }
    }
}