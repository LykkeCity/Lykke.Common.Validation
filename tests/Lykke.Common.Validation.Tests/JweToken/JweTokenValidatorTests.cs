using Lykke.Common.Validation.JweToken;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.Helpers;
using Lykke.Common.Validation.Tests.JweToken.TestData;
using NUnit.Framework;


namespace Lykke.Common.Validation.Tests.JweToken
{
    public class JweTokenValidatorTests
    {
        private readonly JweTokenValidator _validator;

        public JweTokenValidatorTests()
        {
            _validator = new JweTokenValidator();
        }

        
        [TestCaseSource(typeof(ValidJweTokenTestData))]
        public void Validate_ValidJweToken_ReturnTrue(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }

        
        [TestCaseSource(typeof(InvalidJweTokenTestData))]
        public void Validate_InvalidJweToken_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NotJweToken", ValidationResultHelper.GetFirstErrorCodeName(result));
        }

        
        [TestCaseSource(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NullOrEmpty", ValidationResultHelper.GetFirstErrorCodeName(result));
        }
    }
}