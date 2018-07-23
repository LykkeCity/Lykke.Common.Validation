using Lykke.Common.Validation.JwsToken;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.Helpers;
using Lykke.Common.Validation.Tests.JwsToken.TestData;
using NUnit.Framework;


namespace Lykke.Common.Validation.Tests.JwsToken
{
    public class JwsTokenValidatorTests
    {
        private readonly JwsTokenValidator _validator;

        public JwsTokenValidatorTests()
        {
            _validator = new JwsTokenValidator();
        }

        
        [TestCaseSource(typeof(ValidJwsTokenTestData))]
        public void Validate_ValidJwsToken_ReturnTrue(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }

        
        [TestCaseSource(typeof(InvalidJwsTokenTestData))]
        public void Validate_InvalidJwsToken_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NotJwsToken", ValidationResultHelper.GetFirstErrorCodeName(result));
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