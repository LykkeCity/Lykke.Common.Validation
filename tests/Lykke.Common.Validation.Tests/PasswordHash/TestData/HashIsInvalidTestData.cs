using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash.TestData
{
    internal class HashIsInvalidTestData : TheoryData<string>
    {
        public HashIsInvalidTestData()
        {
            Add("123456");
        }
    }
}