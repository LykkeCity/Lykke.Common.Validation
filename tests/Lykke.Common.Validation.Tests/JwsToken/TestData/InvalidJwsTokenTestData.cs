using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.JwsToken.TestData
{
    internal class InvalidJwsTokenTestData : IEnumerable
    {
        private readonly string[] _data =
        {
            "a/1.b2.c3",
            "a1.b/2.c3",
            "a1.b2.c/3",            
            "a123.bc321./1/rMoJ/-0PMHET4",
            "a123.bc321.+1+rMoJ+-0PMHET4",
            "a123.bc321.=1+rMoJ=0PMHET4",
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}