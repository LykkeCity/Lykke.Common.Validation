using System.Collections.Immutable;

namespace Lykke.Common.Validation.NoSpecialCharacters
{
    /// <summary>
    ///     Interface for storing configuration for <see cref="NoSpecialCharactersValidator" />.
    ///     To setup validator use <see cref="INoSpecialCharactersConfigurationExpression" />.
    /// </summary>
    public interface INoSpecialCharactersConfiguration
    {
        /// <summary>
        ///     Set of allowed characters.
        ///     This characters would be recognized as valid and would NOT fail validation if they
        ///     appear in input string.
        /// </summary>
        ImmutableHashSet<char> AllowedChars { get; }

        /// <summary>
        ///     Set of restricted characters.
        ///     This characters would be recognized as invalid and would fail validation if they
        ///     appear in input string.
        ///     Please pay attention that this characters are ADDITIONAL restriction to default set of restricted characters in
        ///     <see cref="NoSpecialCharactersValidator" />.
        /// </summary>
        ImmutableHashSet<char> RestrictedChars { get; }

        /// <summary>
        ///     Indicates Null is a valid value.
        /// </summary>
        bool IsNullAllowed { get; }

        /// <summary>
        ///     Indicates Empty string is a valid value.
        /// </summary>
        bool IsEmptyAllowed { get; }
    }
}