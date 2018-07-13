using System.Linq;

namespace Lykke.Common.Validation.NoSpecialCharacters
{
    /// <summary>
    ///     Validates string does not contain special characters:
    ///     !@#$%^&amp;*()-_=+:;.,"'\/?&lt;&gt;|~[]{}`
    /// </summary>
    public class NoSpecialCharactersValidator
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
        ///     If <paramref name="input" /> does not contain special characters.
        ///     <see cref="NoSpecialCharactersValidationResult" /> does not contain any <see cref="NoSpecialCharactersErrorCode" />
        ///     errors.
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