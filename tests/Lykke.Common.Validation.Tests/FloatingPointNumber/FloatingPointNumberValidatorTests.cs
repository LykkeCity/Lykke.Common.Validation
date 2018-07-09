using System.Linq;
using Lykke.Common.Validation.FloatingPointNumber;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.FloatingPointNumber.TestData;
using Xunit;

namespace Lykke.Common.Validation.Tests.FloatingPointNumber
{
    public class FloatingPointNumberValidatorTests
    {
        private readonly FloatingPointNumberValidator _validator;

        public FloatingPointNumberValidatorTests()
        {
            _validator = new FloatingPointNumberValidator();
        }

        [Theory]
        [ClassData(typeof(ValidFloatingPointTestData))]
        public void Validate_ValidFloatingPoint_ReturnTrue(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }

        [Theory]
        [ClassData(typeof(InvalidFloatingPointTestData))]
        public void Validate_InvalidFloatingPoint_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(FloatingPointNumberErrorCode.NotFloaringPoint, result.ErrorCodes.First());
        }

        [Theory]
        [ClassData(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(FloatingPointNumberErrorCode.NullOrEmpty, result.ErrorCodes.First());
        }
    }
}