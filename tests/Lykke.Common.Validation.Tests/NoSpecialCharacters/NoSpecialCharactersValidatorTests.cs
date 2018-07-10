using System.Linq;
using Lykke.Common.Validation.NoSpecialCharacters;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData;
using NUnit.Framework;


namespace Lykke.Common.Validation.Tests.NoSpecialCharacters
{
    public class NoSpecialCharactersValidatorTests
    {
        private readonly NoSpecialCharactersValidator _validator;

        public NoSpecialCharactersValidatorTests()
        {
            _validator = new NoSpecialCharactersValidator();
        }

        
        [TestCaseSource(typeof(WithoutSpecialCharactersTestData))]
        public void Validate_WithoutSpecialCharacters_ReturnTrue(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }

        
        [TestCaseSource(typeof(WithSpecialCharactersTestData))]
        public void Validate_WithSpecialCharacters_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual(NoSpecialCharactersErrorCode.ContainsSpecialCharacters, result.ErrorCodes.First());
        }

        
        [TestCaseSource(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual(NoSpecialCharactersErrorCode.NullOrEmpty, result.ErrorCodes.First());
        }
    }
}