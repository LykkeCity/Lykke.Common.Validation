using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash.TestData
{
    internal class HashIsNullTestData : TheoryData<string>
    {
        public HashIsNullTestData()
        {
            Add(null);
        }
    }
}