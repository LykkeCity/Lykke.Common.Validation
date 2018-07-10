using System.Collections.Generic;

namespace Lykke.Common.Validation.Tests.ValidationResult
{
    internal class TestValidationResult : ValidationResult<TestErrorCode>
    {
        public TestValidationResult()
        {
        }

        public TestValidationResult(TestErrorCode errorCode) : base(errorCode)
        {
        }

        public TestValidationResult(IEnumerable<TestErrorCode> errorCodes) : base(errorCodes)
        {
        }
    }
}