using System.Collections;
using System.Linq;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData
{
    internal class WithoutSpecialCharactersTestData : IEnumerable
    {
        private readonly string[] _data =
        {
            "Name Surname",
            "Имя Фамилия",
            "東海林賢蔵",
            "Kāneohe",
            "Kißlegg Baden Württemberg ",
            "Trøndelag",
            "บริษัท ปตท",
            "จำกัด",
            "삼성전자",
            "中国工商银行股份有限公司",
            "トヨタ自動車株式会社"
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}