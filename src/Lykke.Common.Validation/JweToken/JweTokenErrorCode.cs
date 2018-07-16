namespace Lykke.Common.Validation.JweToken
{
    /// <summary>
    ///     <see cref="JweTokenValidationResult"/> error codes.
    /// </summary>
    public enum JweTokenErrorCode
    {
        /// <summary>
        ///     Input is null or empty string.
        /// </summary>
        NullOrEmpty,

        /// <summary>
        ///     Input is not a Jwe token.
        /// </summary>
        NotJweToken
    }
}