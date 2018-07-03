using System.Linq;
using Lykke.Common.Validation.Tests.Helpers;
using Lykke.Common.Validation.Tests.ImageTypes.TestData;
using Lykke.Common.Validation.Tests.ImageTypes.TestModels;
using Xunit;

namespace Lykke.Common.Validation.Tests.ImageTypes.Attribute
{
    public class ImageTypeIFormFileAttributeTests
    {
        private const string ExpectedErrorMessage =
            "File must be an image file. Allowed extensions are: .jpg, .jpeg, .png, .gif, .bmp.";

        [Theory]
        [ClassData(typeof(InvalidFileSignatureTestData))]
        public void Validate_FileHasInvalidSignature_HaveInvalidSignatureErrorMessage(
            ImageTypeTestDataDto dto)
        {
            // Assert
            var model = new ImageTypeIFormFileTestModel
            {
                File = dto.File
            };

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, results.First().ErrorMessage);

            // Dispose
            dto.Stream?.Dispose();
        }

        [Theory]
        [ClassData(typeof(FileIsNullTestData))]
        public void Validate_FileIsNull_HaveValueNotIFormFileErrorMessage(
            ImageTypeTestDataDto dto)
        {
            // Assert
            var model = new ImageTypeIFormFileTestModel
            {
                File = dto.File
            };

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, results.First().ErrorMessage);

            // Dispose
            dto.Stream?.Dispose();
        }

        [Theory]
        [ClassData(typeof(InvalidFileExtensionTestData))]
        public void Validate_FileExtensionIsInvalid_HaveInvalidExtensionErrorMessage(
            ImageTypeTestDataDto dto)
        {
            // Assert
            var model = new ImageTypeIFormFileTestModel
            {
                File = dto.File
            };

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(ExpectedErrorMessage, results.First().ErrorMessage);

            // Dispose
            dto.Stream?.Dispose();
        }

        [Theory]
        [ClassData(typeof(FileIsNullTestData))]
        public void Validate_FileIsNullWithCustomMessage_FormatsCustomErrorMessage(
            ImageTypeTestDataDto dto)
        {
            // Assert
            const string expectedErrorMessage = "File is not a .jpg image.";

            var model = new ImageTypeIFormFileCustomMessageTestModel
            {
                File = dto.File
            };

            // Act
            var results = AttributeTestHelper.Validate(model);

            // Assert
            Assert.Equal(expectedErrorMessage, results.First().ErrorMessage);

            // Dispose
            dto.Stream?.Dispose();
        }
    }
}