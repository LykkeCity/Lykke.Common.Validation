using System.Collections.Generic;
using System.Collections.Immutable;

namespace Lykke.Common.Validation.Configuration
{
    internal class ValidationConfiguration : IValidationConfiguration
    {
        public IReadOnlyCollection<char> ZeroWidthChars { get; internal set; }
    }
}
