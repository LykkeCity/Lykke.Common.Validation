namespace Lykke.Common.Validation.FloatingPointNumber
{
    /// <summary>
    ///     <see cref="FloatingPointNumberValidator" /> validation result.
    /// </summary>
    public class FloatingPointNumberValidationResult : ValidationResult<FloatingPointNumberErrorCode>
    {
        /// <inheritdoc/>
        public FloatingPointNumberValidationResult()
        {
        }

        /// <inheritdoc/>
        public FloatingPointNumberValidationResult(FloatingPointNumberErrorCode errorCode) : base(errorCode)
        {
        }
    }
}