using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.IsOnlyDigits.TestData
{
    internal class InvalidIsOnlyDigitsTestData : IEnumerable
    {
        private readonly string[] _data =
        {
            "abcd",
            "123abc",
            "><?/*-",
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}