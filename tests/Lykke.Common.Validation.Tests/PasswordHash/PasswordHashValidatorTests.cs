using Lykke.Common.Validation.PasswordHash;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.Helpers;
using Lykke.Common.Validation.Tests.PasswordHash.TestData;
using NUnit.Framework;


namespace Lykke.Common.Validation.Tests.PasswordHash
{
    public class PasswordHashValidatorTests
    {
        private readonly PasswordHashValidator _validator;

        public PasswordHashValidatorTests()
        {
            _validator = new PasswordHashValidator();
        }

        
        [TestCaseSource(typeof(HashIsValidSha256TestData))]
        public void Validate_HashIsValidSHA256Hash_ReturnTrue(string passwordHash)
        {
            // Act
            var result = _validator.Validate(passwordHash);

            // Assert
            Assert.True(result.IsValid);
        }

        
        [TestCaseSource(typeof(HashIsInvalidTestData))]
        public void Validate_HashIsNotSHA256_ReturnFalse(string passwordHash)
        {
            // Act
            var result = _validator.Validate(passwordHash);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NotSha256", ValidationResultHelper.GetFirstErrorCodeName(result));
        }

        
        [TestCaseSource(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_ReturnFalse(string passwordHash)
        {
            // Act
            var result = _validator.Validate(passwordHash);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NullOrEmpty", ValidationResultHelper.GetFirstErrorCodeName(result));
        }
    }
}