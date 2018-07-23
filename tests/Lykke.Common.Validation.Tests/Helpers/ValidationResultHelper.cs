using System;
using System.Globalization;
using System.Linq;

namespace Lykke.Common.Validation.Tests.Helpers
{
    /// <summary>
    ///     Helper class for <see cref="ValidationResult{TEnum}" />.
    /// </summary>
    internal static class ValidationResultHelper
    {
        /// <summary>
        ///     Get first error code name if result is invalid.
        /// </summary>
        /// <typeparam name="TEnum">ErrorCode type.</typeparam>
        /// <param name="result">ValidationResult of some validator.</param>
        /// <returns>
        ///     Name of first error if result contains errors.
        ///     Empty string if result is valid.
        /// </returns>
        /// <exception cref="ArgumentException">If <typeparamref name="TEnum" /> is not enum.</exception>
        public static string GetFirstErrorCodeName<TEnum>(ValidationResult<TEnum> result)
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException($"{nameof(TEnum)} is not enum!");

            return result.IsValid
                ? string.Empty
                : result.ErrorCodes.First().ToString(CultureInfo.InvariantCulture);
        }
    }
}