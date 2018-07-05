using Lykke.Common.Validation.ImageTypes.Base;
using Lykke.Common.Validation.Tests.ImageTypes.TestData;
using Xunit;

namespace Lykke.Common.Validation.Tests.ImageTypes.Base
{
    public class ImageTypeIFormFileBaseValidatorTests
    {
        public ImageTypeIFormFileBaseValidatorTests()
        {
            _baseValidator = new ImageTypeBaseValidator(".jpg", ".jpeg", ".png", ".gif", ".bmp");
        }

        private readonly ImageTypeBaseValidator _baseValidator;

        [Theory]
        [ClassData(typeof(InvalidFileSignatureTestData))]
        public void IsValid_FileHasInvalidSignature_ReturnFalse(
            ImageTypeTestDataDto dto)
        {
            // Assert
            Assert.False(_baseValidator.IsValid(dto.File.FileName, dto.Stream));

            // Dispose
            dto.Stream?.Dispose();
        }

        [Fact]
        public void IsValid_FileExtensionIsInvalid_ReturnFalse()
        {
            // Assert
            Assert.False(_baseValidator.IsValid("Test.tiff", null));
        }

        [Fact]
        public void IsValid_FileIsNull_ReturnFalse()
        {
            // Assert
            Assert.False(_baseValidator.IsValid("Test.jpg", null));
        }

        [Theory]
        [ClassData(typeof(ValidFileTestData))]
        public void IsValid_FileIsNull_ReturnTrue(
            ImageTypeTestDataDto dto)
        {
            // Assert
            Assert.True(_baseValidator.IsValid(dto.File.FileName, dto.Stream));

            // Dispose
            dto.Stream?.Dispose();
        }
    }
}