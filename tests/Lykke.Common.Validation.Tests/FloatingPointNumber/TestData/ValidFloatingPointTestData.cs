using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.FloatingPointNumber.TestData
{
    internal class ValidFloatingPointTestData : IEnumerable
    {
        private readonly string[] _data =
        {
            "123",
            "-123.35",
            "-123.35e-2",
            "+321.52e+20",
            "123e+10"
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}