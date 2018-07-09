using System.Linq;
using Lykke.Common.Validation.PasswordHash;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.PasswordHash.TestData;
using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash
{
    public class PasswordHashValidatorTests
    {
        private readonly PasswordHashValidator _validator;

        public PasswordHashValidatorTests()
        {
            _validator = new PasswordHashValidator();
        }

        [Theory]
        [ClassData(typeof(HashIsValidSha256TestData))]
        public void Validate_HashIsValidSHA256Hash_ReturnTrue(string passwordHash)
        {
            // Act
            var result = _validator.Validate(passwordHash);

            // Assert
            Assert.True(result.IsValid);
        }

        [Theory]
        [ClassData(typeof(HashIsInvalidTestData))]
        public void Validate_HashIsNotSHA256_ReturnFalse(string passwordHash)
        {
            // Act
            var result = _validator.Validate(passwordHash);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(PasswordHashErrorCode.NotSha256, result.ErrorCodes.First());
        }

        [Theory]
        [ClassData(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_ReturnFalse(string passwordHash)
        {
            // Act
            var result = _validator.Validate(passwordHash);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(PasswordHashErrorCode.NullOrEmpty, result.ErrorCodes.First());
        }
    }
}