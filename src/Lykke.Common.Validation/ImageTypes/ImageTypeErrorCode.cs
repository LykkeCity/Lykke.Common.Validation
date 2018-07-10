namespace Lykke.Common.Validation.ImageTypes
{
    /// <summary>
    ///     <see cref="ImageTypeValidationResult"/> error codes.
    /// </summary>
    public enum ImageTypeErrorCode
    {
        /// <summary>
        ///     File name is null or empty.
        /// </summary>
        FileNameNullOrWhitespace,

        /// <summary>
        ///     Extension in file name is empty or not in valid extension list.
        /// </summary>
        FileExtensionEmptyOrInvalid,

        /// <summary>
        ///     File stream is null.
        /// </summary>
        FileStreamIsNull,

        /// <summary>
        ///     File stream is shorter than longest valid signature.
        /// </summary>
        FileStreamIsTooShort,

        /// <summary>
        ///     File signature is invalid.
        /// </summary>
        InvalidHexSignature
    }
}