namespace Lykke.Common.Validation.NoSpecialCharacters
{
    /// <summary>
    ///     Interface for setting additional allowed and restricted characters for
    ///     <see cref="NoSpecialCharactersValidator" />.
    ///     Used in constructor to create <see cref="INoSpecialCharactersConfiguration" /> inside validator.
    /// </summary>
    public interface INoSpecialCharactersConfigurationExpression
    {
        /// <summary>
        ///     Sets allowed characters.
        ///     This characters won't fail validation and would be excluded from default set of restricted characters for
        ///     <see cref="NoSpecialCharactersValidator" />.
        /// </summary>
        /// <param name="chars">Allowed characters.</param>
        void SetAllowed(params char[] chars);

        /// <summary>
        ///     Sets additional restricted characters.
        ///     This characters would fail validation in addition with default set of restricted characters for
        ///     <see cref="NoSpecialCharactersValidator" />.
        /// </summary>
        /// <param name="chars">Restricted characters.</param>
        void SetRestricted(params char[] chars);

        /// <summary>
        ///     Allow Null to be considered as valid.
        /// </summary>
        void AllowNull();

        /// <summary>
        ///     Allow Empty string to be considered as valid.
        /// </summary>
        void AllowEmpty();
    }
}