using System;
using System.Linq;

namespace Lykke.Common.Validation.NoSpecialCharacters
{
    /// <summary>
    ///     Validates string does not contain special characters:
    /// </summary>
    public class NoSpecialCharactersValidator
    {
        /// <summary>
        ///     Set of default restricted characters.
        /// </summary>
        private static readonly char[] DefaultRestrictedCharacters =
        {
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '_', '=', ':', ';', '.', ',', '"', '\'', '\\',
            '/', '|', '?', '<', '>', '~', '[', ']', '{', '}', '`'
        };

        /// <summary>
        ///     Set of characters to be validated for.
        ///     If input string contains any of these characters, validation result would be
        ///     negative.
        ///     By default, equals to <see cref="DefaultRestrictedCharacters" />.
        ///     Could be modified with additional allowed and restricted characters through constructor with configuration.
        /// </summary>
        private readonly char[] _restrictedCharacters;

        /// <summary>
        ///     Constructs validator with default set of restricted characters.
        ///     !@#$%^&amp;*()-_=+:;.,"'\/?&lt;&gt;|~[]{}`
        /// </summary>
        public NoSpecialCharactersValidator()
        {
            _restrictedCharacters = DefaultRestrictedCharacters;
        }

        /// <summary>
        ///     Constructs validator with custom set of allowed and restricted characters.
        /// </summary>
        /// <param name="configAction">
        ///     Delegate to configure validator. Used for setting allowed characters and add additional restricted characters.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="configAction" /> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if you set same characters for allowed and restricted.</exception>
        public NoSpecialCharactersValidator(Action<INoSpecialCharactersConfigurationExpression> configAction) : this()
        {
            if (configAction == null)
                throw new ArgumentNullException(nameof(configAction));

            var builder = new NoSpecialCharactersConfigurationBuilder();
            configAction(builder);
            var config = builder.Build();

            if (config.AllowedChars != null && config.AllowedChars.Count > 0)
                _restrictedCharacters = _restrictedCharacters.Except(config.AllowedChars).ToArray();

            if (config.RestrictedChars != null && config.RestrictedChars.Count > 0)
                _restrictedCharacters = _restrictedCharacters.Union(config.RestrictedChars).ToArray();
        }

        /// <summary>
        ///     Validates string does not contain special characters.
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

            var isContainSpecialCharacters = input.Length > _restrictedCharacters.Length
                ? _restrictedCharacters.Any(input.Contains)
                : input.Any(_restrictedCharacters.Contains);

            return isContainSpecialCharacters
                ? new NoSpecialCharactersValidationResult(NoSpecialCharactersErrorCode.ContainsSpecialCharacters)
                : new NoSpecialCharactersValidationResult();
        }
    }
}