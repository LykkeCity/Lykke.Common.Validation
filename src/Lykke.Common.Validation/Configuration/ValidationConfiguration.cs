using System.Collections.Generic;

namespace Lykke.Common.Validation.Configuration
{
    internal class ValidationConfiguration : IValidationConfiguration
    {
        public IReadOnlyCollection<char> ZeroWidthChars { get; internal set; }
    }
}
