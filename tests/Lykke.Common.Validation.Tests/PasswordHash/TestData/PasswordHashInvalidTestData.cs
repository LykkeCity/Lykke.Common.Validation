using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash.TestData
{
    internal class PasswordHashInvalidTestData : TheoryData<string>
    {
        public PasswordHashInvalidTestData()
        {
            Add(null);
            Add("");
            Add("123456");
        }
    }
}