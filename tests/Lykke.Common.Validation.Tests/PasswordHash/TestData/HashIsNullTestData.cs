using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash.TestData
{
    internal class HashIsEmptyStringTestData : TheoryData<string>
    {
        public HashIsEmptyStringTestData()
        {
            Add(string.Empty);
        }
    }
}