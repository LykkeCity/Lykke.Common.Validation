namespace Lykke.Common.Validation.ImageTypes
{
    /// <summary>
    ///     <see cref="ImageTypeValidator" /> validation result.
    /// </summary>
    public class ImageTypeValidationResult : ValidationResult<ImageTypeErrorCode>
    {
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