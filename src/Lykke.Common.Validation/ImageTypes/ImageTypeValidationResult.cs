namespace Lykke.Common.Validation.ImageTypes
{
    /// <summary>
    ///     <see cref="ImageTypeValidator" /> validation result.
    /// </summary>
    public class ImageTypeValidationResult : ValidationResult<ImageTypeErrorCode>
    {
        /// <summary>
        /// List of file allowed extensions.
        /// </summary>
        public string AllowedExtensions { get; internal set; }

        /// <inheritdoc />
        public ImageTypeValidationResult()
        {
        }

        /// <inheritdoc />
        public ImageTypeValidationResult(ImageTypeErrorCode errorCode) : base(errorCode)
        {
        }
    }
}