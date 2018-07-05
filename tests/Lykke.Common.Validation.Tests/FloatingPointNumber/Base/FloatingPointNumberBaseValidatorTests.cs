using Lykke.Common.Validation.FloatingPointNumber.Base;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.FloatingPointNumber.TestData;
using Xunit;

namespace Lykke.Common.Validation.Tests.FloatingPointNumber.Base
{
    public class FloatingPointNumberBaseValidatorTests
    {
        private readonly FloatingPointNumberBaseValidator _baseValidator;

        public FloatingPointNumberBaseValidatorTests()
        {
            _baseValidator = new FloatingPointNumberBaseValidator();
        }

        [Theory]
        [ClassData(typeof(ValidFloatingPointTestData))]
        public void IsValid_ValidFloatingPoint_ReturnTrue(string input)
        {
            Assert.True(_baseValidator.IsValid(input));
        }

        [Theory]
        [ClassData(typeof(InvalidFloatingPointTestData))]
        public void IsValid_InvalidFloatingPoint_ReturnFalse(string input)
        {
            Assert.False(_baseValidator.IsValid(input));
        }        
        
        [Theory]
        [ClassData(typeof(NullOrEmptyStringTestData))]
        public void IsValid_NullOrEmpty_ReturnFalse(string input)
        {
            Assert.False(_baseValidator.IsValid(input));
        }
    }
}