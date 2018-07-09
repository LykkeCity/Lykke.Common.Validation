namespace Lykke.Common.Validation.FloatingPointNumber
{
    /// <summary>
    ///     Validates string is a floating point number.
    ///     This class contains common logic to use inside Lykke.Common.Validation package only.
    ///     If you need new Validator for your needs, create a wrapper around this class and use it.
    /// </summary>
    internal class FloatingPointNumberValidator
    {
        /// <summary>
        ///     Validates string is a floating point number.
        /// </summary>
        /// <param name="input">String to validate.</param>
        /// <returns>
        ///     True if <paramref name="input" /> can be converted to a floating point number.
        /// </returns>
        public FloatingPointNumberValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new FloatingPointNumberValidationResult(FloatingPointNumberErrorCode.NullOrEmpty);

            var isFloatingPoint = double.TryParse(input, out _);

            return isFloatingPoint
                ? new FloatingPointNumberValidationResult()
                : new FloatingPointNumberValidationResult(FloatingPointNumberErrorCode.NotFloaringPoint);
        }
    }
}