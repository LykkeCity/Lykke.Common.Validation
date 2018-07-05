using System.Linq;
using FluentValidation.TestHelper;
using Lykke.Common.Validation.Tests.Helpers;
using Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData;
using Lykke.Common.Validation.Tests.NoSpecialCharacters.TestModels;
using Xunit;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters.Fluent
{
    public class NoSpecialCharactersValidatorTests
    {
        private const string ExpectedErrorMessage =
            "Input must not contain special characters.";

        private readonly NoSpecialCharactersTestValidator _testValidator;

        public NoSpecialCharactersValidatorTests()
        {
            _testValidator = new NoSpecialCharactersTestValidator();
        }

        [Theory]
        [ClassData(typeof(WithSpecialCharacters))]
        public void Validate_WithSpecialCharacters_HaveErrorMessage(string input)
        {
            // Assert
            var model = new NoSpecialCharactersTestModel {Input = input};

            // Act
            var result = _testValidator.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, result.Errors.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_HaveErrorMessage(string input)
        {
            // Assert
            var model = new NoSpecialCharactersTestModel {Input = input};

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
            _testValidator.ShouldNotHaveValidationErrorFor(model => model.Input, input);
        }
    }
}