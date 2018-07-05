using Xunit;

namespace Lykke.Common.Validation.Tests.FloatingPointNumber.TestData
{
    internal class ValidFloatingPointTestData : TheoryData<string>
    {
        public ValidFloatingPointTestData()
        {
            Add("123");
            Add("-123.35");
            Add("-123.35e-2");
            Add("+321.52e+20");
            Add("123e+10");
        }
    }
}