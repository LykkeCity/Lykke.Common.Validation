namespace Lykke.Common.Validation.JwsToken
{
    /// <summary>
    ///     <see cref="JwsTokenValidationResult"/> error codes.
    /// </summary>
    public enum JwsTokenErrorCode
    {
        /// <summary>
        ///     Input is null or empty string.
        /// </summary>
        NullOrEmpty,

        /// <summary>
        ///     Input is not a JWS token.
        /// </summary>
        NotJwsToken
    }
}