using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.JwsToken.TestData
{
    internal class ValidJwsTokenTestData : IEnumerable
    {
        private readonly string[] _data =
        {
            "eyJhbGciOiJIUzI1NiIsImV4cCI6IjIwMTgtMDUtMjlUMDk6MDA6NTkuMTgyMzI4NFoifQ.eyJoZWxsbyI6IndvcmxkIn0.TuD2MOkZ1rmTp_PuDKl_1_rMoJ_uJYmyeYH-0PMHET4"
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}