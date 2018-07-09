using Xunit;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData
{
    internal class WithoutSpecialCharactersTestData : TheoryData<string>
    {
        public WithoutSpecialCharactersTestData()
        {
            Add("Name Surname");
            Add("Имя Фамилия");
            Add("東海林賢蔵");
            Add("Kāneohe");
            Add("Kißlegg Baden Württemberg ");
            Add("Trøndelag");
            Add("บริษัท ปตท");
            Add("จำกัด");
            Add("삼성전자");
            Add("中国工商银行股份有限公司");
            Add("トヨタ自動車株式会社");
        }
    }
}