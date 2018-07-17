namespace Lykke.Common.Validation.StreamMaxSize
{
    /// <summary>
    ///     <see cref="StreamMaxSizeValidator" /> validation result.
    /// </summary>
    public class StreamMaxSizeValidationResult : ValidationResult<StreamMaxSizeErrorCode>
    {
        /// <summary>
        ///     Stream max allowed size in Kb.
        /// </summary>
        public long MaxSizeKb { get; internal set; }

        /// <inheritdoc />
        public StreamMaxSizeValidationResult()
        {
        }

        /// <inheritdoc />
        public StreamMaxSizeValidationResult(StreamMaxSizeErrorCode errorCode) : base(errorCode)
        {
        }
    }
}