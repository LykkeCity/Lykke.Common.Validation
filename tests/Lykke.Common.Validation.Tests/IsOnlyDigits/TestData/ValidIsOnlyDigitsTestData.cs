using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.IsOnlyDigits.TestData
{
    internal class ValidIsOnlyDigitsTestData : IEnumerable
    {
        private readonly string[] _data =
        {
            "1",
            "123456"
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}