using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.CommonTestData
{
    internal class NullOrEmptyStringTestData : IEnumerable
    {
        private readonly string[] _data =
        {
            null,
            string.Empty
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}