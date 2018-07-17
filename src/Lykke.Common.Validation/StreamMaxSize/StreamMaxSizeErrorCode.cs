namespace Lykke.Common.Validation.StreamMaxSize
{
    /// <summary>
    ///     <see cref="StreamMaxSizeValidationResult"/> error codes.
    /// </summary>
    public enum StreamMaxSizeErrorCode
    {
        /// <summary>
        ///     Stream is null.
        /// </summary>
        Null,

        /// <summary>
        ///     Stream is longer than max size.
        /// </summary>
        LongerThanMaxSize
    }
}