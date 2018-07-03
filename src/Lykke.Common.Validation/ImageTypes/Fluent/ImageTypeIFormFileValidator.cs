using FluentValidation.Validators;
using Lykke.Common.Validation.ImageTypes.Base;
using Microsoft.AspNetCore.Http;

namespace Lykke.Common.Validation.ImageTypes.Fluent
{
    /// <summary>
    ///     Deep image validator.
    ///     Error message additional arguments:
    ///     {AllowedExtensions} - allowed file extensions set for validator.
    ///     Use only on <see cref="IFormFile" />.
    ///     Validates extension and file signature by checking first bytes.
    ///     Available file extensions: ".jpg", ".jpeg", ".png", ".gif", ".bmp".
    ///     Any other extensions would be ignored.
    /// </summary>
    public class ImageTypeIFormFileValidator : PropertyValidator
    {
        private readonly ImageTypeBaseValidator _imageTypeBaseValidator;

        public ImageTypeIFormFileValidator(params string[] imageExtensions) : base(
            "{PropertyName} must be an image file. Allowed extensions are: {AllowedExtensions}.")
        {
            _imageTypeBaseValidator = new ImageTypeBaseValidator(imageExtensions);
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            context.MessageFormatter.AppendArgument("AllowedExtensions", _imageTypeBaseValidator.AllowedExtensions);

            if (!(context.PropertyValue is IFormFile file))
                return false;

            using (var fileStream = file.OpenReadStream())
            {
                return _imageTypeBaseValidator.IsValid(file.FileName, fileStream);
            }
        }
    }
}