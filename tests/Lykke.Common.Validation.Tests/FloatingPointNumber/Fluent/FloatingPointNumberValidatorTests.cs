using System.Linq;
using FluentValidation.TestHelper;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.FloatingPointNumber.TestData;
using Lykke.Common.Validation.Tests.FloatingPointNumber.TestModels;
using Xunit;

namespace Lykke.Common.Validation.Tests.FloatingPointNumber.Fluent
{
    public class FloatingPointNumberValidatorTests
    {
        private const string ExpectedErrorMessage =
            "Input must be a floating point number.";

        private readonly FloatingPointNumberTestValidator _testValidator;

        public FloatingPointNumberValidatorTests()
        {
            _testValidator = new FloatingPointNumberTestValidator();
        }

        [Theory]
        [ClassData(typeof(InvalidFloatingPointTestData))]
        public void Validate_InvalidFloatingPoint_HaveErrorMessage(string input)
        {
            // Assert
            var model = new FloatingPointNumberTestModel {Input = input};

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
            var model = new FloatingPointNumberTestModel {Input = input};

            // Act
            var result = _testValidator.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, result.Errors.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(ValidFloatingPointTestData))]
        public void Validate_ValidFloatingPoint_NotHaveErrorMessage(string input)
        {
            _testValidator.ShouldNotHaveValidationErrorFor(model => model.Input, input);
        }
    }
}