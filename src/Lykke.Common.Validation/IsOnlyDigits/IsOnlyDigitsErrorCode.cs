namespace Lykke.Common.Validation.IsOnlyDigits
{
    /// <summary>
    ///     <see cref="IsOnlyDigitsValidationResult"/> error codes.
    /// </summary>
    public enum IsOnlyDigitsErrorCode
    {
        /// <summary>
        ///     Input is null or empty string.
        /// </summary>
        NullOrEmpty,

        /// <summary>
        ///     Input does not consist only of digits.
        /// </summary>
        NotOnlyDigits,
    }
}