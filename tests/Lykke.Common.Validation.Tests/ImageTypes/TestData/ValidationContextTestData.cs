using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.ImageTypes.TestData
{
    internal class ValidationContextTestData : IEnumerable
    {
        private readonly string[][] _data =
        {
            new[] {".jpg"},
            new[] {".png"},
            new[] {".bmp", ".jpeg", ".gif"}
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}