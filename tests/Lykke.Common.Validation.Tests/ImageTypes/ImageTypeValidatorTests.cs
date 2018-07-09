using System.IO;
using System.Linq;
using Lykke.Common.Validation.ImageTypes;
using Lykke.Common.Validation.Tests.ImageTypes.TestData;
using Xunit;

namespace Lykke.Common.Validation.Tests.ImageTypes
{
    public class ImageTypeValidatorTests
    {
        public ImageTypeValidatorTests()
        {
            _validator = new ImageTypeValidator(".jpg", ".jpeg", ".png", ".gif", ".bmp");
        }

        private readonly ImageTypeValidator _validator;

        [Theory]
        [ClassData(typeof(ValidFileTestData))]
        public void Validate_FileIsNull_ReturnTrue(
            ImageTypeTestDataDto dto)
        {
            // Act
            var result = _validator.Validate(dto.File.FileName, dto.Stream);

            // Assert
            Assert.True(result.IsValid);

            // Dispose
            dto.Stream?.Dispose();
        }

        [Fact]
        // TODO: Add check for bull or empty file name
        public void Validate_FileExtensionIsInvalid_ReturnFalse()
        {
            // Act
            var result = _validator.Validate("Test.tiff", null);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ImageTypeErrorCode.FileExtensionEmptyOrInvalid, result.ErrorCodes.First());
        }

        [Fact]
        public void Validate_FileNameIsNullOrEmpty_ReturnFalse()
        {
            // Act
            var result = _validator.Validate("", null);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ImageTypeErrorCode.FileNameNullOrWhitespace, result.ErrorCodes.First());
        }

        [Fact]
        // TODO: Add check for FileStream null
        public void Validate_FileStreamIsNull_ReturnFalse()
        {
            // Act
            var result = _validator.Validate("Test.jpg", null);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ImageTypeErrorCode.FileStreamIsNull, result.ErrorCodes.First());
        }

        [Fact]
        // TODO: Add check for FileStream null
        public void Validate_FileStreamIsTooShort_ReturnFalse()
        {
            // Arrange
            var stream = new MemoryStream(new byte[] {1});

            // Act
            var result = _validator.Validate("Test.jpg", stream);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ImageTypeErrorCode.FileStreamIsTooShort, result.ErrorCodes.First());
        }

        [Theory]
        [ClassData(typeof(InvalidFileSignatureTestData))]
        public void Validate_FileHasInvalidSignature_ReturnFalse(
            ImageTypeTestDataDto dto)
        {
            // Act
            var result = _validator.Validate(dto.File.FileName, dto.Stream);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ImageTypeErrorCode.InvalidHexSignature, result.ErrorCodes.First());

            // Dispose
            dto.Stream?.Dispose();
        }
    }
}