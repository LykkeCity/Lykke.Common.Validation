using System.IO;

namespace Lykke.Common.Validation.StreamMaxSize
{
    /// <summary>
    ///     Validates stream size.
    /// </summary>
    public class StreamMaxSizeValidator
    {
        private readonly long _maxSizeKb;

        /// <summary>
        ///     Create validator for stream size.
        /// </summary>
        /// <param name="maxSizeKb">
        ///     Max size in Kb.
        /// </param>
        public StreamMaxSizeValidator(long maxSizeKb)
        {
            _maxSizeKb = maxSizeKb;
        }

        /// <summary>
        ///     Validates stream size.
        /// </summary>
        /// <param name="stream">Stream to validate.</param>
        /// <returns>
        ///     If <paramref name="stream" /> length is less than <see cref="_maxSizeKb" />
        ///     <see cref="StreamMaxSizeValidationResult" /> does not contain any <see cref="StreamMaxSizeErrorCode" /> errors.
        /// </returns>
        public StreamMaxSizeValidationResult Validate(Stream stream)
        {
            var result = new StreamMaxSizeValidationResult {MaxSizeKb = _maxSizeKb};

            using (stream)
            {
                if (stream == null)
                {
                    result.Add(StreamMaxSizeErrorCode.Null);
                    return result;
                }

                if(stream.Length <= _maxSizeKb * 1024)
                    return result;

                result.Add(StreamMaxSizeErrorCode.LongerThanMaxSize);
                return result;
            }
        }
    }
}