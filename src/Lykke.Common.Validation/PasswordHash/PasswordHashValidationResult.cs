namespace Lykke.Common.Validation.PasswordHash
{
    /// <summary>
    ///     <see cref="PasswordHashValidator" /> validation result.
    /// </summary>
    public class PasswordHashValidationResult : ValidationResult<PasswordHashErrorCode>
    {
        /// <inheritdoc />
        public PasswordHashValidationResult()
        {
        }

        /// <inheritdoc />
        public PasswordHashValidationResult(PasswordHashErrorCode errorCode) : base(errorCode)
        {
        }
    }
}