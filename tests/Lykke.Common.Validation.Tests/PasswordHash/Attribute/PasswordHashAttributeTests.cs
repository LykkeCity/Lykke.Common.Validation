using System.Linq;
using Lykke.Common.Validation.PasswordHash.Attribute;
using Lykke.Common.Validation.Tests.Helpers;
using Lykke.Common.Validation.Tests.PasswordHash.TestData;
using Lykke.Common.Validation.Tests.PasswordHash.TestModels;
using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash.Attribute
{
    public class PasswordHashAttributeTests
    {
        private const string ExpectedErrorMessage = "PasswordHash must be valid SHA-256 hash.";


        [Theory]
        [ClassData(typeof(HashIsInvalidTestData))]
        public void Validate_HashIsNotSHA256_HaveErrorMessage(string passwordHash)
        {
            // Assert
            var model = new PasswordHashTestModel
            {
                PasswordHash = passwordHash
            };

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, results.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(HashIsNullTestData))]
        public void Validate_HashIsNull_HaveErrorMessage(string passwordHash)
        {
            // Assert
            var model = new PasswordHashTestModel
            {
                PasswordHash = passwordHash
            };

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, results.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(HashIsEmptyStringTestData))]
        public void Validate_HashIsEmptyString_HaveErrorMessage(string passwordHash)
        {
            // Assert
            var model = new PasswordHashTestModel
            {
                PasswordHash = passwordHash
            };

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, results.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(HashIsValidSHA256TestData))]
        public void Validate_IsValidSHA256Hash_NotHaveErrorMessage(string passwordHash)
        {
            // Assert
            var model = new PasswordHashTestModel
            {
                PasswordHash = passwordHash
            };

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(0, results.Count);
        }


        [Theory]
        [ClassData(typeof(HashIsNullTestData))]
        public void Validate_HashIsNullWithCustomMessage_FormatsCustomErrorMessage(string passwordHash)
        {
            // Assert
            const string expectedErrorMessage = "PasswordHash With Custom Error Message.";
            var model = new PasswordHashCustomMessageTestModel
            {
                PasswordHash = passwordHash
            };

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(expectedErrorMessage, results.First().ErrorMessage);
        }
    }
}