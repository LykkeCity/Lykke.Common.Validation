using Xunit;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData
{
    internal class NullOrEmptyStringTestData : TheoryData<string>
    {
        public NullOrEmptyStringTestData()
        {
            Add(null);
            Add(string.Empty);
        }
    }
}