using System.Text.RegularExpressions;

namespace Lykke.Common.Validation.JweToken
{
    /// <summary>
    ///     Validates string is a Jwe token.
    /// </summary>
    public class JweTokenValidator
    {
        private static readonly Regex JweRegex =
            new Regex("^[a-zA-Z0-9-_]+?\\.([a-zA-Z0-9-_]+)?\\.[a-zA-Z0-9-_]+?\\.[a-zA-Z0-9-_]+?\\.[a-zA-Z0-9-_]+?$", RegexOptions.Compiled);

        /// <summary>
        ///     Validates string is a Jwe token.
        /// </summary>
        /// <param name="input">String to validate.</param>
        /// <returns>
        ///     If <paramref name="input" /> is a Jwe token.
        ///     <see cref="JweTokenValidationResult" /> does not contain any <see cref="JweTokenErrorCode" />
        ///     errors.
        /// </returns>
        public JweTokenValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new JweTokenValidationResult(JweTokenErrorCode.NullOrEmpty);

            return JweRegex.IsMatch(input)
                ? new JweTokenValidationResult()
                : new JweTokenValidationResult(JweTokenErrorCode.NotJweToken);
        }
    }
}