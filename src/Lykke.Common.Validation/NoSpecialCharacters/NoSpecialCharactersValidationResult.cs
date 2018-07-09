namespace Lykke.Common.Validation.NoSpecialCharacters
{
    /// <summary>
    ///     <see cref="NoSpecialCharactersValidator" /> validation result.
    /// </summary>
    public class NoSpecialCharactersValidationResult : ValidationResult<NoSpecialCharactersErrorCode>
    {
        /// <inheritdoc />
        public NoSpecialCharactersValidationResult()
        {
        }

        /// <inheritdoc />
        public NoSpecialCharactersValidationResult(NoSpecialCharactersErrorCode errorCode) : base(errorCode)
        {
        }
    }
}