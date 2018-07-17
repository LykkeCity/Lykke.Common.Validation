using System.Text.RegularExpressions;

namespace Lykke.Common.Validation.JwsToken
{
    /// <summary>
    ///     Validates string is a JWS token.
    /// </summary>
    public class JwsTokenValidator
    {
        private static readonly Regex JwsRegex =
            new Regex("^[a-zA-Z0-9-_]+?\\.[a-zA-Z0-9-_]+?\\.([a-zA-Z0-9-_]+)?$", RegexOptions.Compiled);

        /// <summary>
        ///     Validates string is a JWS token.
        /// </summary>
        /// <param name="input">String to validate.</param>
        /// <returns>
        ///     If <paramref name="input" /> is a JWS token.
        ///     <see cref="JwsTokenValidationResult" /> does not contain any <see cref="JwsTokenErrorCode" />
        ///     errors.
        /// </returns>
        public JwsTokenValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new JwsTokenValidationResult(JwsTokenErrorCode.NullOrEmpty);

            return JwsRegex.IsMatch(input)
                ? new JwsTokenValidationResult()
                : new JwsTokenValidationResult(JwsTokenErrorCode.NotJwsToken);
        }
    }
}