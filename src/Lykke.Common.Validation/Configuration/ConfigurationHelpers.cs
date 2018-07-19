using System;
using System.Linq;

namespace Lykke.Common.Validation.Configuration
{
    /// <summary> Provides some static methods to simplify configuration </summary>
    public static class ConfigurationHelpers
    {
        /// <summary> Splits unescaped string to chars </summary>
        public static char[] UnescapedStringToCharsArray(string config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            return System.Text.RegularExpressions.Regex.Unescape(config)
                .Distinct()
                .ToArray();
        }
    }
}
