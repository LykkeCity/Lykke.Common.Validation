using System.Collections.Generic;

namespace Lykke.Common.Validation.Tests.ValidationResult
{
    internal class InvalidTestValidationResult : ValidationResult<InvalidEnum>
    {
        public InvalidTestValidationResult()
        {
        }

        public InvalidTestValidationResult(InvalidEnum errorCode) : base(errorCode)
        {
        }

        public InvalidTestValidationResult(IEnumerable<InvalidEnum> errorCodes) : base(errorCodes)
        {
        }
    }
}