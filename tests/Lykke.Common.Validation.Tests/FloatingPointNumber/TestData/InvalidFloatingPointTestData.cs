using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.FloatingPointNumber.TestData
{
    internal class InvalidFloatingPointTestData : IEnumerable
    {
        private readonly string[] _data =
        {
            "abc",
            " ? @ # %",
            "12asdb312",
            "123 312"
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}