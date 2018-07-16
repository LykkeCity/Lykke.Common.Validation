namespace Lykke.Common.Validation.IsOnlyDigits
{
    /// <summary>
    ///     <see cref="IsOnlyDigitsValidator" /> validation result.
    /// </summary>
    public class IsOnlyDigitsValidationResult : ValidationResult<IsOnlyDigitsErrorCode>
    {
        public int MaxLength;

        /// <inheritdoc />
        public IsOnlyDigitsValidationResult()
        {
        }

        /// <inheritdoc />
        public IsOnlyDigitsValidationResult(IsOnlyDigitsErrorCode errorCode) : base(errorCode)
        {
        }
    }
}