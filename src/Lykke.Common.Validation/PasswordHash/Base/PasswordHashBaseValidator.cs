using System.Text.RegularExpressions;

namespace Lykke.Common.Validation.PasswordHash.Base
{
    internal class PasswordHashBaseValidator
    {
        private static readonly Regex PasswordHashRegex =
            new Regex("^[A-Fa-f0-9]{64}$", RegexOptions.Compiled);

        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return PasswordHashRegex.IsMatch(input);
        }
    }
}