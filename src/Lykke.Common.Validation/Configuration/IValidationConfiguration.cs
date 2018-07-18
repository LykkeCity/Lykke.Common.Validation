using System.Collections.Generic;

namespace Lykke.Common.Validation.Configuration
{
    /// <summary> Provides configuration of LykkeValidation </summary>
    public interface IValidationConfiguration
    {
        /// <summary>Configured zero-width chars </summary>
        IReadOnlyCollection<char> ZeroWidthChars { get; }
    }
}
