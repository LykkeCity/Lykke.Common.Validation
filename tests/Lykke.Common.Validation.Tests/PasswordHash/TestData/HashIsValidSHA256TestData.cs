using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash.TestData
{
    internal class HashIsValidSha256TestData : TheoryData<string>
    {
        public HashIsValidSha256TestData()
        {
            Add("8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92");
            Add("8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92");
        }
    }
}