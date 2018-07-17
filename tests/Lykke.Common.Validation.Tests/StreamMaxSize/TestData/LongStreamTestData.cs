using System.Collections;
using System.IO;
using System.Linq;

namespace Lykke.Common.Validation.Tests.StreamMaxSize.TestData
{
    internal class LongStreamTestData : IEnumerable
    {
        public LongStreamTestData()
        {
            _byteData = new byte[1025];
            for (var i = 0; i < _byteData.Length; i++) _byteData[i] = 0xFF;

            _data = new Stream[]
            {
                new MemoryStream(_byteData)
            };
        }

        private readonly Stream[] _data;

        private readonly byte[] _byteData;

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}