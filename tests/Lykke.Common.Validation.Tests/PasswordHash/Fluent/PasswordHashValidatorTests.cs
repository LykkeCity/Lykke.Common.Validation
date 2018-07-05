using System.Linq;
using FluentValidation.TestHelper;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.PasswordHash.TestData;
using Lykke.Common.Validation.Tests.PasswordHash.TestModels;
using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash.Fluent
{
    public class PasswordHashValidatorTests
    {
        private const string ExpectedErrorMessage =
            "Password Hash must be valid SHA-256 hash.";

        private readonly PasswordHashTestValidator _testValidator;

        public PasswordHashValidatorTests()
        {
            _testValidator = new PasswordHashTestValidator();
        }

        [Theory]
        [ClassData(typeof(HashIsInvalidTestData))]
        public void Validate_HashIsNotSHA256_HaveErrorMessage(string passwordHash)
        {
            // Arrange
            var invalidImageSignature = new PasswordHashTestModel {PasswordHash = passwordHash};

            // Act
            var result = _testValidator.Validate(invalidImageSignature);

            // Assert
            Assert.Equal(ExpectedErrorMessage, result.Errors.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_HaveErrorMessage(string passwordHash)
        {
            // Arrange
            var invalidImageSignature = new PasswordHashTestModel {PasswordHash = passwordHash};

            // Act
            var result = _testValidator.Validate(invalidImageSignature);

            // Assert
            Assert.Equal(ExpectedErrorMessage, result.Errors.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(HashIsValidSha256TestData))]
        public void Validate_IsValidSHA256Hash_NotHaveErrorMessage(string passwordHash)
        {
            // Assert
            _testValidator.ShouldNotHaveValidationErrorFor(model => model.PasswordHash, passwordHash);
        }
    }
}