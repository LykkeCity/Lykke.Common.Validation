using Lykke.Common.Validation.IsOnlyDigits;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.Helpers;
using Lykke.Common.Validation.Tests.IsOnlyDigits.TestData;
using NUnit.Framework;


namespace Lykke.Common.Validation.Tests.IsOnlyDigits
{
    public class IsOnlyDigitsValidatorTests
    {
        private readonly IsOnlyDigitsValidator _validator;

        public IsOnlyDigitsValidatorTests()
        {
            _validator = new IsOnlyDigitsValidator();
        }
        
        [TestCaseSource(typeof(ValidIsOnlyDigitsTestData))]
        public void Validate_OnlyDigits_ReturnTrue(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }
        
        [TestCaseSource(typeof(InvalidIsOnlyDigitsTestData))]
        public void Validate_NotOnlyDigits_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NotOnlyDigits", ValidationResultHelper.GetFirstErrorCodeName(result));
        }

        
        [TestCaseSource(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NullOrEmpty", ValidationResultHelper.GetFirstErrorCodeName(result));
        }
    }
}