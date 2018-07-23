using System.IO;
using Lykke.Common.Validation.ImageTypes;
using Lykke.Common.Validation.Tests.Helpers;
using Lykke.Common.Validation.Tests.ImageTypes.TestData;
using NUnit.Framework;


namespace Lykke.Common.Validation.Tests.ImageTypes
{
    public class ImageTypeValidatorTests
    {
        public ImageTypeValidatorTests()
        {
            _validator = new ImageTypeValidator(".jpg", ".jpeg", ".png", ".gif", ".bmp");
        }

        private readonly ImageTypeValidator _validator;

        
        [TestCaseSource(typeof(ValidFileTestData))]
        public void Validate_ValidFile_ReturnTrue(
            ImageTypeTestDataDto dto)
        {
            // Act
            var result = _validator.Validate(dto.File.FileName, dto.Stream);

            // Assert
            Assert.True(result.IsValid);

            // Dispose
            dto.Stream?.Dispose();
        }

        
        [TestCaseSource(typeof(ValidationContextTestData))]
        public void Validate_InvalidResult_HasAllowedExtensionsValidationContext(string[] allowedExtensions)
        {
            // Arrange
            var validator = new ImageTypeValidator(allowedExtensions);

            // Act
            var result = validator.Validate("", null);

            // Assert
            var expected = string.Join(", ", allowedExtensions);
            Assert.AreEqual(expected, result.AllowedExtensions);
        }

        
        [TestCaseSource(typeof(InvalidFileSignatureTestData))]
        public void Validate_FileHasInvalidSignature_ReturnFalse(
            ImageTypeTestDataDto dto)
        {
            // Act
            var result = _validator.Validate(dto.File.FileName, dto.Stream);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("InvalidHexSignature", ValidationResultHelper.GetFirstErrorCodeName(result));

            // Dispose
            dto.Stream?.Dispose();
        }

        [Test]
        public void Validate_FileExtensionIsInvalid_ReturnFalse()
        {
            // Act
            var result = _validator.Validate("Test.tiff", null);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("FileExtensionEmptyOrInvalid", ValidationResultHelper.GetFirstErrorCodeName(result));
        }

        [Test]
        public void Validate_FileNameIsNullOrEmpty_ReturnFalse()
        {
            // Act
            var result = _validator.Validate("", null);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("FileNameNullOrWhitespace", ValidationResultHelper.GetFirstErrorCodeName(result));
        }

        [Test]
        public void Validate_FileStreamIsNull_ReturnFalse()
        {
            // Act
            var result = _validator.Validate("Test.jpg", null);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("FileStreamIsNull", ValidationResultHelper.GetFirstErrorCodeName(result));
        }

        [Test]
        public void Validate_FileStreamIsTooShort_ReturnFalse()
        {
            // Arrange
            var stream = new MemoryStream(new byte[] {1});

            // Act
            var result = _validator.Validate("Test.jpg", stream);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual("FileStreamIsTooShort", ValidationResultHelper.GetFirstErrorCodeName(result));
        }
    }
}