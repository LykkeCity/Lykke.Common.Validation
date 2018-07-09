using System.Collections.Generic;

namespace Lykke.Common.Validation.FloatingPointNumber
{
    public class FloatingPointNumberValidationResult : ValidationResult<FloatingPointNumberErrorCode>
    {
        public FloatingPointNumberValidationResult()
        {
        }

        public FloatingPointNumberValidationResult(FloatingPointNumberErrorCode errorCode) : base(errorCode)
        {
        }

        protected FloatingPointNumberValidationResult(IEnumerable<FloatingPointNumberErrorCode> errorCodes) :
            base(errorCodes)
        {
        }
    }
}