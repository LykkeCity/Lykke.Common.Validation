using Lykke.Common.Validation.Tests.Helpers;
using Lykke.Common.Validation.Tests.PasswordHash.TestData;
using Lykke.Common.Validation.Tests.PasswordHash.TestModels;
using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash
{
    public class PasswordHashAttributeTests
    {
        [Theory]
        [ClassData(typeof(PasswordHashInvalidTestData))]
        public void Should_Be_Invalid(string passwordHash)
        {
            // Assert
            var model = new PasswordHashTestModel
            {
                PasswordHash = passwordHash
            };

            // Act
            var results = AttributeTestModelHelper.Validate(model);

            // Assert
            Assert.Equal(1, results.Count);
        }

        [Theory]
        [ClassData(typeof(PasswordHashValidTestData))]
        public void Should_Be_Valid(string passwordHash)
        {
            // Assert
            var model = new PasswordHashTestModel
            {
                PasswordHash = passwordHash
            };

            // Act
            var results = AttributeTestModelHelper.Validate(model);

            // Assert
            Assert.Equal(0, results.Count);
        }
    }
}