using System.Collections.Generic;

namespace Lykke.Common.Validation.NoSpecialCharacters
{
    public class NoSpecialCharactersValidationResult : ValidationResult<NoSpecialCharactersErrorCode>
    {
        public NoSpecialCharactersValidationResult()
        {
        }

        public NoSpecialCharactersValidationResult(NoSpecialCharactersErrorCode errorCode) : base(errorCode)
        {
        }

        protected NoSpecialCharactersValidationResult(IEnumerable<NoSpecialCharactersErrorCode> errorCodes) :
            base(errorCodes)
        {
        }
    }
}