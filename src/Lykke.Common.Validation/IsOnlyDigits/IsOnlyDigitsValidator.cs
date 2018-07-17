using System.Linq;
using Common;

namespace Lykke.Common.Validation.IsOnlyDigits
{
    /// <summary>
    ///     Validates string consists only of digits.
    /// </summary>
    public class IsOnlyDigitsValidator
    {
        /// <summary>
        ///     Validates string consists only of digits.
        /// </summary>
        /// <param name="input">String to validate.</param>
        /// <returns>
        ///     If <paramref name="input" /> consists only of digits.
        ///     <see cref="IsOnlyDigitsValidationResult" /> does not contain any <see cref="IsOnlyDigitsErrorCode" />
        ///     errors.
        /// </returns>
        public IsOnlyDigitsValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new IsOnlyDigitsValidationResult(IsOnlyDigitsErrorCode.NullOrEmpty);

            return input.All(c => c.IsDigit())
                ? new IsOnlyDigitsValidationResult()
                : new IsOnlyDigitsValidationResult(IsOnlyDigitsErrorCode.NotOnlyDigits);
        }
    }
}