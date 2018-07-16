namespace Lykke.Common.Validation.JwsToken
{
    /// <summary>
    ///     <see cref="JwsTokenValidator" /> validation result.
    /// </summary>
    public class JwsTokenValidationResult : ValidationResult<JwsTokenErrorCode>
    {
        /// <inheritdoc />
        public JwsTokenValidationResult()
        {
        }

        /// <inheritdoc />
        public JwsTokenValidationResult(JwsTokenErrorCode errorCode) : base(errorCode)
        {
        }
    }
}