using System.Linq;
using FluentValidation.TestHelper;
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
            Assert.False(result.IsValid);
            Assert.Equal(ExpectedErrorMessage, result.Errors.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(HashIsNullTestData))]
        public void Validate_HashIsNull_HaveErrorMessage(string passwordHash)
        {
            // Arrange
            var invalidImageSignature = new PasswordHashTestModel {PasswordHash = passwordHash};

            // Act
            var result = _testValidator.Validate(invalidImageSignature);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ExpectedErrorMessage, result.Errors.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(HashIsEmptyStringTestData))]
        public void Validate_HashIsEmptyString_HaveErrorMessage(string passwordHash)
        {
            // Arrange
            var invalidImageSignature = new PasswordHashTestModel {PasswordHash = passwordHash};

            // Act
            var result = _testValidator.Validate(invalidImageSignature);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ExpectedErrorMessage, result.Errors.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(HashIsValidSHA256TestData))]
        public void Validate_IsValidSHA256Hash_NotHaveErrorMessage(string passwordHash)
        {
            // Assert
            _testValidator.ShouldNotHaveValidationErrorFor(model => model.PasswordHash, passwordHash);
        }
    }
}