﻿using System;
using System.Linq;
using Lykke.Common.Validation.NoSpecialCharacters;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData;
using NUnit.Framework;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters
{
    public class NoSpecialCharactersValidatorTests
    {
        [TestCaseSource(typeof(WithoutSpecialCharactersTestData))]
        public void Validate_WithoutSpecialCharacters_ReturnTrue(string input)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator();

            // Act
            var result = validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }


        [TestCaseSource(typeof(WithSpecialCharactersTestData))]
        public void Validate_WithSpecialCharacters_ReturnFalse(string input)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator();

            // Act
            var result = validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual(NoSpecialCharactersErrorCode.ContainsSpecialCharacters, result.ErrorCodes.First());
        }


        [TestCaseSource(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_ReturnFalse(string input)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator();

            // Act
            var result = validator.Validate(input);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual(NoSpecialCharactersErrorCode.NullOrEmpty, result.ErrorCodes.First());
        }

        [TestCase(new[] {'a', 'b', 'c'}, new[] {'c'})]
        public void Constructor_AllowedAndRestrictedCharactersContainsSameCharacters_ThrowsException(
            char[] allowedCharacters, char[] additionalRestrictedCharacters)
        {
            // Arrange
            const string expectedMessage = "AllowedChars should not contain characters from RestrictedChars!";

            // Assert
            var exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    // ReSharper disable once ObjectCreationAsStatement
                    new NoSpecialCharactersValidator(c =>
                    {
                        c.SetAllowed(allowedCharacters);
                        c.SetRestricted(additionalRestrictedCharacters);
                    });
                });
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void Constructor_ConfigActionIsNull_ThrowsException()
        {
            // Arrange
            const string expectedMessage = "Value cannot be null.\r\nParameter name: configAction";

            // Assert
            var exception = Assert.Throws<ArgumentNullException>(
                () =>
                {
                    // ReSharper disable once ObjectCreationAsStatement
                    new NoSpecialCharactersValidator(null);
                });
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestCase("a,b,c,d.", new[] {',', '.'})]
        [TestCase("a/b!{c}d_e+f", new[] {'/', '!', '{', '}', '_', '+'})]
        public void Validate_ValidStringWithSetAdditionalAllowedCharacters_ReturnsTrue(string input,
            char[] allowedCharacters)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator(c => { c.SetAllowed(allowedCharacters); });

            // Assert
            Assert.True(validator.Validate(input).IsValid);
        }

        [TestCase("abcd", new[] {'a', 'c'})]
        [TestCase("a1b2c3d4e5", new[] {'1', '5'})]
        public void Validate_InvalidStringWithAdditionalRestrictedCharacters_ReturnsFalse(string input,
            char[] additionalRestrictedCharacters)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator(c => { c.SetRestricted(additionalRestrictedCharacters); });

            // Assert
            Assert.False(validator.Validate(input).IsValid);
        }
    }
}