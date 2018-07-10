using System;
using NUnit.Framework;


namespace Lykke.Common.Validation.Tests.ValidationResult
{
    public class ValidationResultTests
    {
        [Test]
        public void DefaultConstructor_ValidEnumType_NotThrow()
        {
            // Assert
            // ReSharper disable once UnusedVariable
            var validationResult = new TestValidationResult();
        }

        [Test]
        public void OneErrorConstructor_ValidEnumType_NotThrow()
        {
            // Assert
            // ReSharper disable once UnusedVariable
            var validationResult = new TestValidationResult(TestErrorCode.TestError1);
        }

        [Test]
        public void ErrorListConstructor_ValidEnumType_NotThrow()
        {
            // Assert
            // ReSharper disable once UnusedVariable
            var validationResult = new TestValidationResult(new[] {TestErrorCode.TestError1, TestErrorCode.TestError2});
        }

        [Test]
        public void DefaultConstructor_InvalidEnumType_ThrowsArgumentException()
        {
            // Assert
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new InvalidTestValidationResult());
        }

        [Test]
        public void OneErrorConstructor_InvalidEnumType_ThrowsArgumentException()
        {
            // Assert
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new InvalidTestValidationResult(new InvalidEnum()));
        }

        [Test]
        public void ErrorListConstructor_InvalidEnumType_ThrowsArgumentException()
        {
            // Assert
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() =>
                new InvalidTestValidationResult(new[] {new InvalidEnum(), new InvalidEnum()}));
        }
    }
}