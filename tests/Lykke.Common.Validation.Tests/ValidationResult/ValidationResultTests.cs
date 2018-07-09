using System;
using Xunit;

namespace Lykke.Common.Validation.Tests.ValidationResult
{
    public class ValidationResultTests
    {
        [Fact]
        public void DefaultConstructor_ValidEnumType_NotThrow()
        {
            // Assert
            // ReSharper disable once UnusedVariable
            var validationResult = new TestValidationResult();
        }

        [Fact]
        public void OneErrorConstructor_ValidEnumType_NotThrow()
        {
            // Assert
            // ReSharper disable once UnusedVariable
            var validationResult = new TestValidationResult(TestErrorCode.TestError1);
        }

        [Fact]
        public void ErrorListConstructor_ValidEnumType_NotThrow()
        {
            // Assert
            // ReSharper disable once UnusedVariable
            var validationResult = new TestValidationResult(new[] {TestErrorCode.TestError1, TestErrorCode.TestError2});
        }

        [Fact]
        public void DefaultConstructor_InvalidEnumType_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new InvalidTestValidationResult());
        }

        [Fact]
        public void OneErrorConstructor_InvalidEnumType_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new InvalidTestValidationResult(new InvalidEnum()));
        }

        [Fact]
        public void ErrorListConstructor_InvalidEnumType_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
                new InvalidTestValidationResult(new[] {new InvalidEnum(), new InvalidEnum()}));
        }
    }
}