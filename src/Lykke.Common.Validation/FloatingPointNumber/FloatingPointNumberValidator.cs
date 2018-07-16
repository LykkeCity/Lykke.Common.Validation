namespace Lykke.Common.Validation.FloatingPointNumber
{
    /// <summary>
    ///     Validates string is a floating point number.
    /// </summary>
    public class FloatingPointNumberValidator
    {
        /// <summary>
        ///     Validates string is a floating point number.
        /// </summary>
        /// <param name="input">String to validate.</param>
        /// <returns>
        ///     If string is a floating point number, 
        ///     <see cref="FloatingPointNumberValidationResult"/> does not contain any <see cref="FloatingPointNumberErrorCode"/> errors.
        /// </returns>
        public FloatingPointNumberValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new FloatingPointNumberValidationResult(FloatingPointNumberErrorCode.NullOrEmpty);

            var isFloatingPoint = double.TryParse(input, out _);

            return isFloatingPoint
                ? new FloatingPointNumberValidationResult()
                : new FloatingPointNumberValidationResult(FloatingPointNumberErrorCode.NotFloatingPoint);
        }
    }
}