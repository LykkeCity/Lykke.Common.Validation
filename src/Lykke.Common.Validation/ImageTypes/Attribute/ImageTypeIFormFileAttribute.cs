using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Lykke.Common.Validation.ImageTypes.Base;
using Microsoft.AspNetCore.Http;

namespace Lykke.Common.Validation.ImageTypes.Attribute
{
    /// <summary>
    ///     Deep image validation.
    ///     Use only on <see cref="IFormFile" />.
    ///     Validates extension and file signature by checking first bytes.
    ///     Available file extensions: ".jpg", ".jpeg", ".png", ".gif", ".bmp".
    ///     Any other extensions would be ignored.
    ///     Supports formatting of ErrorMessage:
    ///     {0} - name of field being validated
    ///     (1) - list of valid file extensions separated by comma
    /// </summary>
    /// <example>
    ///     Example of using with custom error message:
    ///     <c>[ImageTypeAttribute(ErrorMessage="File {0} should be valid {1} image.")]</c>
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ImageTypeIFormFileAttribute : ValidationAttribute
    {
        private readonly string _allowedExtensions;
        private readonly string _defaultErrorMessage = "{0} must be an image file. Allowed extensions are: {1}.";

        private readonly ImageTypeBaseValidator _imageTypeBaseValidator;

        public ImageTypeIFormFileAttribute(params string[] imageExtensions)
        {
            _imageTypeBaseValidator = new ImageTypeBaseValidator(imageExtensions);
            _allowedExtensions = _imageTypeBaseValidator.AllowedExtensions;
        }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var displayName = validationContext.DisplayName;

            var errorResult = new ValidationResult(FormatErrorMessage(displayName));

            if (!(value is IFormFile file))
                return errorResult;

            using (var fileStream = file.OpenReadStream())
            {
                return _imageTypeBaseValidator.IsValid(file.FileName, fileStream)
                    ? ValidationResult.Success
                    : errorResult;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            var errorMessage = string.IsNullOrWhiteSpace(ErrorMessage) ? _defaultErrorMessage : ErrorMessage;

            return string.Format(CultureInfo.CurrentCulture, errorMessage, name, _allowedExtensions);
        }
    }
}