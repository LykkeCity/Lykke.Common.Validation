using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.PasswordHash.TestData
{
    internal class HashIsValidSha256TestData : IEnumerable
    {
        private readonly string[] _data =
        {
            "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
            "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92"
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}