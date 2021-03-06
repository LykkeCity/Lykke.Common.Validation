﻿using Lykke.Common.Validation.FloatingPointNumber;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.FloatingPointNumber.TestData;
using Lykke.Common.Validation.Tests.Helpers;
using NUnit.Framework;


namespace Lykke.Common.Validation.Tests.FloatingPointNumber
{
    public class FloatingPointNumberValidatorTests
    {
        private readonly FloatingPointNumberValidator _validator;

        public FloatingPointNumberValidatorTests()
        {
            _validator = new FloatingPointNumberValidator();
        }

        
        [TestCaseSource(typeof(ValidFloatingPointTestData))]
        public void Validate_ValidFloatingPoint_ReturnTrue(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }

        
        [TestCaseSource(typeof(InvalidFloatingPointTestData))]
        public void Validate_InvalidFloatingPoint_ReturnFalse(string input)
        {
            // Act
            var result = _validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NotFloatingPoint", ValidationResultHelper.GetFirstErrorCodeName(result));
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