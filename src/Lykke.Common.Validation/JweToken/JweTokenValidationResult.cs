namespace Lykke.Common.Validation.JweToken
{
    /// <summary>
    ///     <see cref="JweTokenValidator" /> validation result.
    /// </summary>
    public class JweTokenValidationResult : ValidationResult<JweTokenErrorCode>
    {
        /// <inheritdoc />
        public JweTokenValidationResult()
        {
        }

        /// <inheritdoc />
        public JweTokenValidationResult(JweTokenErrorCode errorCode) : base(errorCode)
        {
        }
    }
}