using Xunit;

namespace Lykke.Common.Validation.Tests.CommonTestData
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