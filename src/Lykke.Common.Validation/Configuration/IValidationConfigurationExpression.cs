using System.Collections.Generic;

namespace Lykke.Common.Validation.Configuration
{
    /// <summary> Provides methods to configure LykkeValidation </summary>
    public interface IValidationConfigurationExpression
    {
        /// <summary>Sets zero-width chars</summary>
        void SetZeroWidthChars(IEnumerable<char> chars);
    }
}
