using System.Linq;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.FloatingPointNumber.TestData;
using Lykke.Common.Validation.Tests.FloatingPointNumber.TestModels;
using Lykke.Common.Validation.Tests.Helpers;
using Xunit;

namespace Lykke.Common.Validation.Tests.FloatingPointNumber.Attribute
{
    public class FloatingPointNumberAttributeTests
    {
        private const string ExpectedErrorMessage = "Input must be a floating point number.";

        [Theory]
        [ClassData(typeof(InvalidFloatingPointTestData))]
        public void Validate_InvalidFloatingPoint_HaveErrorMessage(string input)
        {
            // Assert
            var model = new FloatingPointNumberTestModel {Input = input};

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
            var model = new FloatingPointNumberTestModel {Input = input};

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, results.First().ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(ValidFloatingPointTestData))]
        public void Validate_ValidFloatingPoint_NotHaveErrorMessage(string input)
        {
            // Assert
            var model = new FloatingPointNumberTestModel {Input = input};

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(0, results.Count);
        }
    }
}