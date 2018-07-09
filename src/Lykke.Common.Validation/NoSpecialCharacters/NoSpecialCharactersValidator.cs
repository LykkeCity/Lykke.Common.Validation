using System.Linq;

namespace Lykke.Common.Validation.NoSpecialCharacters
{
    /// <summary>
    ///     Validates string does not contain special characters:
    ///     !@#$%^&amp;*()-_=+:;.,"'\/?&lt;&gt;|~[]{}`
    ///     This class contains common logic to use inside Lykke.Common.Validation package only.
    ///     If you need new Validator for your needs, create a wrapper around this class and use it.
    /// </summary>
    internal class NoSpecialCharactersValidator
    {
        private static readonly char[] RestrictedCharacters =
        {
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '_', '=', ':', ';', '.', ',', '"', '\'', '\\',
            '/', '|', '?', '<', '>', '~', '[', ']', '{', '}', '`'
        };

        /// <summary>
        ///     Validates string does not contain special characters:
        ///     !@#$%^&amp;*()-_=+:;.,"'\/?&lt;&gt;|~[]{}`
        /// </summary>
        /// <param name="input">String to validate.</param>
        /// <returns>
        ///     True if <paramref name="input" /> does not contain special characters.
        /// </returns>
        public NoSpecialCharactersValidationResult Validate(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new NoSpecialCharactersValidationResult(NoSpecialCharactersErrorCode.NullOrEmpty);

            var isContainSpecialCharacters = input.Length > RestrictedCharacters.Length
                ? RestrictedCharacters.Any(input.Contains)
                : input.Any(RestrictedCharacters.Contains);

            return isContainSpecialCharacters
                ? new NoSpecialCharactersValidationResult(NoSpecialCharactersErrorCode.ContainsSpecialCharacters)
                : new NoSpecialCharactersValidationResult();
        }
    }
}