namespace Lykke.Common.Validation.InputConvertors
{
    /// <summary> Provides methods for fixing user input </summary>
    public interface IInputStringConvertors
    {
        /// <summary>
        /// Replaces unusual spaces to normal (\u0020).
        /// Replaces multiple spaces to single.
        /// Removes leading and trailing spaces.
        /// </summary>
        string FixIrregularSpaces(string source);

        /// <summary> Removes zero-width chars </summary>
        string RemoveZeroWidthChars(string source);

        /// <summary> Combines other methods to provide security </summary>
        string FixFraudMixes(string source);
    }
}