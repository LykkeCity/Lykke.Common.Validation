using System.Collections.Generic;

namespace Lykke.Common.Validation.PasswordHash
{
    public class PasswordHashValidationResult : ValidationResult<PasswordHashErrorCode>
    {
        public PasswordHashValidationResult()
        {
        }

        public PasswordHashValidationResult(PasswordHashErrorCode errorCode) : base(errorCode)
        {
        }

        protected PasswordHashValidationResult(IEnumerable<PasswordHashErrorCode> errorCodes) : base(errorCodes)
        {
        }
    }
}