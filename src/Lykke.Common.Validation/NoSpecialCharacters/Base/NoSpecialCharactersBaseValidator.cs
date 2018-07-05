using System.Linq;

namespace Lykke.Common.Validation.NoSpecialCharacters.Base
{
    /// <summary>
    ///     Validates string does not contain special characters.
    ///     This class contains common logic to use inside Lykke.Common.Validation package only.
    ///     If you need new Validator for your needs, create a wrapper around this class and use it.
    /// </summary>
    internal class NoSpecialCharactersBaseValidator
    {
        private static readonly char[] RestrictedCharacters = 
        {
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '_', '=', ':', ';', '.', ',', '"', '\'', '\\',
            '/', '|', '?', '<', '>', '~', '[', ']', '{', '}', '`'
        };

        public bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            return input.All(c => !RestrictedCharacters.Contains(c));
        }
    }
}