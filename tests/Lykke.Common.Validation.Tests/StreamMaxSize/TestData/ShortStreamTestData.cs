using System.Collections;
using System.IO;
using System.Linq;

namespace Lykke.Common.Validation.Tests.StreamMaxSize.TestData
{
    internal class ShortStreamTestData : IEnumerable
    {
        private readonly Stream[] _data =
        {
            new MemoryStream(new byte[] {1})
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}