using Xunit;

namespace Lykke.Common.Validation.Tests.FloatingPointNumber.TestData
{
    internal class InvalidFloatingPointTestData : TheoryData<string>
    {
        public InvalidFloatingPointTestData()
        {
            Add("abc");
            Add(" ? @ # %");
            Add("123,321");
            Add("12asdb312");
            Add("123 312");
        }
    }
}