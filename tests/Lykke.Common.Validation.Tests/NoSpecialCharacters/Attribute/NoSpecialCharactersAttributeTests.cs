using System.Linq;
using Lykke.Common.Validation.Tests.Helpers;
using Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData;
using Lykke.Common.Validation.Tests.NoSpecialCharacters.TestModels;
using Xunit;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters.Attribute
{
    public class NoSpecialCharactersAttributeTests
    {
        private const string ExpectedErrorMessage = "Input must not contain special characters.";

        [Theory]
        [ClassData(typeof(WithSpecialCharacters))]
        public void Validate_WithSpecialCharacters_HaveErrorMessage(string input)
        {
            // Assert
            var model = new NoSpecialCharactersTestModel{Input = input};

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, results.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_HaveErrorMessage(string input)
        {
            // Assert
            var model = new NoSpecialCharactersTestModel{Input = input};

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, results.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(WithoutSpecialCharacters))]
        public void Validate_WithoutSpecialCharacters_NotHaveErrorMessage(string input)
        {
            // Assert
            var model = new NoSpecialCharactersTestModel{Input = input};

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(0, results.Count);
        }
    }
}