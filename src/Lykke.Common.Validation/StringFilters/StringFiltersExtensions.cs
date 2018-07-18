using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lykke.Common.Validation.StringFilters
{
    /// <summary>Provides extension methods for fitering user input strings</summary>
    public static class StringFiltersExtensions
    {
        private static readonly Regex MultipleSpacesRegex = new Regex("[\\s]{1,}", RegexOptions.Compiled);

        /// <summary> Default white space </summary>
        public const char NormalSpace = '\u0020';

        /// <summary>
        /// Replaces unusual spaces to \u0020.
        /// Replaces multiple spaces to single.
        /// Removes leading and trailing spaces.
        /// </summary>
        public static string RemoveIrregularSpaces(this string source)
        {
            return MultipleSpacesRegex
                .Replace(source, NormalSpace.ToString())
                .Trim();
        }

        /// <summary> Removes zero-width chars </summary>
        public static string RemoveZeroWidthChars(this string source)
        {
            var charsToRemove = LykkeValidation.Configuration?.ZeroWidthChars;

            if (charsToRemove == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(LykkeValidation)}.{nameof(LykkeValidation.Configuration)}.{nameof(LykkeValidation.Configuration.ZeroWidthChars)} is not specified. " +
                    $"Use {nameof(LykkeValidation)}.{nameof(LykkeValidation.Initialize)}() specify it.");
            }

            return new string(source.Split(charsToRemove.ToArray()).SelectMany(x => x).ToArray());
        }

        /// <summary> Combines other filters to provide security </summary>
        public static string RemoveFraudMixes(this string source)
        {
            return source
                .RemoveZeroWidthChars()
                .RemoveIrregularSpaces();
        }
    }
}
