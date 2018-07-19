using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lykke.Common.Validation.InputConvertors
{
    /// <inheritdoc />
    public class InputStringConvertors : IInputStringConvertors
    {
        private const char NormalSpace = '\u0020';
        private static readonly Regex MultipleSpacesRegex = new Regex("\\s+", RegexOptions.Compiled);

        internal readonly char[] ZeroWidthChars;

        /// <summary> Creates instance based on LykkeValidation.Configuration </summary>
        public InputStringConvertors()
        {
            var zeroWidthChars = LykkeValidation.Configuration?.ZeroWidthChars;

            if (zeroWidthChars == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(LykkeValidation)}.{nameof(LykkeValidation.Configuration)}.{nameof(LykkeValidation.Configuration.ZeroWidthChars)} is not specified. " +
                    $"Use {nameof(LykkeValidation)}.{nameof(LykkeValidation.Initialize)}() specify it. " +
                     "Or use other constructor.");
            }

            ZeroWidthChars = zeroWidthChars.Distinct().ToArray();
        }

        /// <summary> Creates instance based on arguments </summary>
        public InputStringConvertors(IEnumerable<char> zeroWidthChars)
        {
            if (zeroWidthChars == null)
            {
                throw new ArgumentNullException(nameof(zeroWidthChars));
            }

            ZeroWidthChars = zeroWidthChars.Distinct().ToArray();
        }

        /// <inheritdoc />
        public string FixIrregularSpaces(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return MultipleSpacesRegex
                .Replace(source, NormalSpace.ToString())
                .Trim();
        }

        /// <inheritdoc />
        public string RemoveZeroWidthChars(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var chars = source
                .Split(ZeroWidthChars)
                .SelectMany(x => x)
                .ToArray();

            return new string(chars);
        }

        /// <inheritdoc />
        public string FixFraudMixes(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return FixIrregularSpaces(RemoveZeroWidthChars(source));
        }
    }
}
