﻿using System.Text.RegularExpressions;

namespace Lykke.Common.Validation.PasswordHash
{
    /// <summary>
    ///     Validates string is a valid SHA-256 hash.
    /// </summary>
    public class PasswordHashValidator
    {
        private static readonly Regex PasswordHashRegex =
            new Regex("^[A-Fa-f0-9]{64}$", RegexOptions.Compiled);

        /// <summary>
        ///     Validates string is a valid SHA-256 hash.
        /// </summary>
        /// <param name="input">String to validate.</param>
        /// <returns>
        ///     If <paramref name="input" /> is a valid SHA-256 hash.
        ///     <see cref="PasswordHashValidationResult" /> does not contain any <see cref="PasswordHashErrorCode" />
        ///     errors.
        /// </returns>
        public PasswordHashValidationResult Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new PasswordHashValidationResult(PasswordHashErrorCode.NullOrEmpty);

            return PasswordHashRegex.IsMatch(input)
                ? new PasswordHashValidationResult()
                : new PasswordHashValidationResult(PasswordHashErrorCode.NotSha256);
        }
    }
}