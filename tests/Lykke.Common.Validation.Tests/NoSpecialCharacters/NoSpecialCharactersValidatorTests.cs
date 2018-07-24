using System;
using FluentAssertions;
using Lykke.Common.Validation.NoSpecialCharacters;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.Helpers;
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
            var errorCode = ValidationResultHelper.GetFirstErrorCodeName(result);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("ContainsSpecialCharacters", errorCode);
        }


        [TestCaseSource(typeof(NullOrEmptyStringTestData))]
        public void Validate_NullOrEmpty_ReturnFalse(string input)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator();

            // Act
            var result = validator.Validate(input);
            var errorCode = ValidationResultHelper.GetFirstErrorCodeName(result);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NullOrEmpty", errorCode);
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
            // Assert
            var exception = Assert.Throws<ArgumentNullException>(
                () =>
                {
                    // ReSharper disable once ObjectCreationAsStatement
                    new NoSpecialCharactersValidator(null);
                });
            exception.Message.Should().ContainAll("Value cannot be null.", "Parameter name: configAction");
        }

        [TestCase("a,b,c,d.", new[] {',', '.'})]
        [TestCase("a/b!{c}d_e+f", new[] {'/', '!', '{', '}', '_', '+'})]
        public void Validate_ValidStringWithSetAdditionalAllowedCharacters_ReturnsTrue(string input,
            char[] allowedCharacters)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator(c => { c.SetAllowed(allowedCharacters); });

            // Act
            var result = validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }

        [TestCase("abcd", new[] {'a', 'c'})]
        [TestCase("a1b2c3d4e5", new[] {'1', '5'})]
        public void Validate_InvalidStringWithAdditionalRestrictedCharacters_ReturnsFalse(string input,
            char[] additionalRestrictedCharacters)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator(c => { c.SetRestricted(additionalRestrictedCharacters); });

            // Act
            var result = validator.Validate(input);
            var errorCode = ValidationResultHelper.GetFirstErrorCodeName(result);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("ContainsSpecialCharacters", errorCode);
        }

        [TestCase(null)]
        public void Validate_NullWhenNullIsAllowed_ReturnsTrue(string input)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator(c => { c.AllowNull(); });

            // Act
            var result = validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }

        [TestCase("")]
        public void Validate_EmptyStringWhenEmptyStringIsAllowed_ReturnsTrue(string input)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator(c => { c.AllowEmpty(); });

            // Act
            var result = validator.Validate(input);

            // Assert
            Assert.True(result.IsValid);
        }

        [TestCase(null)]
        public void Validate_NullWhenEmptyStringIsAllowed_ReturnsFalse(string input)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator(c => { c.AllowEmpty(); });

            // Act
            var result = validator.Validate(input);
            var errorCode = ValidationResultHelper.GetFirstErrorCodeName(result);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NullOrEmpty", errorCode);
        }       
        
        [TestCase("")]
        public void Validate_EmptyStringWhenNullIsAllowed_ReturnsFalse(string input)
        {
            // Arrange
            var validator = new NoSpecialCharactersValidator(c => { c.AllowNull(); });

            // Act
            var result = validator.Validate(input);
            var errorCode = ValidationResultHelper.GetFirstErrorCodeName(result);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("NullOrEmpty", errorCode);
        }
    }
}