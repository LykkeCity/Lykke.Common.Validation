namespace Lykke.Common.Validation.NoSpecialCharacters
{
    /// <summary>
    ///     <see cref="NoSpecialCharactersValidationResult"/> error codes.
    /// </summary>
    public enum NoSpecialCharactersErrorCode
    {
        /// <summary>
        ///     Input is null or empty string.
        /// </summary>
        NullOrEmpty,

        /// <summary>
        ///     Input contains restricted characters.
        /// </summary>
        ContainsSpecialCharacters
    }
}