namespace Lykke.Common.Validation.PasswordHash
{
    /// <summary>
    ///     <see cref="PasswordHashValidationResult"/> error codes.
    /// </summary>
    public enum PasswordHashErrorCode
    {
        /// <summary>
        ///     Input is null or empty string.
        /// </summary>
        NullOrEmpty,

        /// <summary>
        ///     Input is not a SHA-256 hash.
        /// </summary>
        NotSha256
    }
}