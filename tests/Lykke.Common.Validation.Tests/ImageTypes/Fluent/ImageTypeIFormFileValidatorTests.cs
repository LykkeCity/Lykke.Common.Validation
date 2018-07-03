using System.Linq;
using FluentValidation.TestHelper;
using Lykke.Common.Validation.Tests.ImageTypes.TestData;
using Lykke.Common.Validation.Tests.ImageTypes.TestModels;
using Xunit;

namespace Lykke.Common.Validation.Tests.ImageTypes.Fluent
{
    public class ImageTypeIFormFileValidatorTests
    {
        private const string ExpectedErrorMessage =
            "File must be an image file. Allowed extensions are: .jpg, .jpeg, .png, .gif, .bmp.";

        private readonly ImageTypeIFormFileTestValidator _iFormFileTestValidator;

        public ImageTypeIFormFileValidatorTests()
        {
            _iFormFileTestValidator = new ImageTypeIFormFileTestValidator();
        }

        [Theory]
        [ClassData(typeof(InvalidFileSignatureTestData))]
        public void Validate_FileHasInvalidSignature_HaveValidationError(ImageTypeTestDataDto dto)
        {
            // Arrange
            var invalidImageSignature = new ImageTypeIFormFileTestModel {File = dto.File};

            // Act
            var result = _iFormFileTestValidator.Validate(invalidImageSignature);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ExpectedErrorMessage, result.Errors.First().ErrorMessage);

            // Dispose
            dto.Stream?.Dispose();
        }

        [Theory]
        [ClassData(typeof(InvalidFileExtensionTestData))]
        public void Validate_FileHasInvalidExtension_HaveValidationError(ImageTypeTestDataDto dto)
        {
            // Arrange
            var invalidImageSignature = new ImageTypeIFormFileTestModel {File = dto.File};

            // Act
            var result = _iFormFileTestValidator.Validate(invalidImageSignature);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ExpectedErrorMessage, result.Errors.First().ErrorMessage);

            // Dispose
            dto.Stream?.Dispose();
        }

        [Theory]
        [ClassData(typeof(FileIsNullTestData))]
        public void Validate_FileIsNull_HaveValidationError(ImageTypeTestDataDto dto)
        {
            // Arrange
            var invalidImageSignature = new ImageTypeIFormFileTestModel {File = dto.File};

            // Act
            var result = _iFormFileTestValidator.Validate(invalidImageSignature);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ExpectedErrorMessage, result.Errors.First().ErrorMessage);

            // Dispose
            dto.Stream?.Dispose();
        }

        [Theory]
        [ClassData(typeof(ValidFileTestData))]
        public void Validate_FileIsValid_NotHaveValidationError(ImageTypeTestDataDto dto)
        {
            // Assert
            _iFormFileTestValidator.ShouldNotHaveValidationErrorFor(model => model.File, dto.File);

            // Dispose
            dto.Stream?.Dispose();
        }
    }
}