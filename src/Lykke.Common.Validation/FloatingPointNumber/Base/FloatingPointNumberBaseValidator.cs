using System.Text.RegularExpressions;

namespace Lykke.Common.Validation.FloatingPointNumber.Base
{
    /// <summary>
    ///     Validates string is a floating point number.
    ///     This class contains common logic to use inside Lykke.Common.Validation package only.
    ///     If you need new Validator for your needs, create a wrapper around this class and use it.
    /// </summary>
    internal class FloatingPointNumberBaseValidator
    {
        private static readonly Regex FloatingPointRegex =
            new Regex("^[-+]?[0-9]+[.]?[0-9]*([eE][-+]?[0-9]+)?$", RegexOptions.Compiled);

        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return FloatingPointRegex.IsMatch(input);
        }
    }
}