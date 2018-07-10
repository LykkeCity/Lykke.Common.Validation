using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.PasswordHash.TestData
{
    internal class HashIsInvalidTestData : IEnumerable
    {
        private readonly string[] _data =
        {
            "123456",
            "3gh1vhg21vghvh"
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}