using Xunit;

namespace Lykke.Common.Validation.Tests.ImageTypes.TestData
{
    internal class ValidationContextTestData : TheoryData<string[]>
    {
        public ValidationContextTestData()
        {
            Add(new[] {".jpg"});
            Add(new[] {".png"});
            Add(new[] {".bmp", ".jpeg", ".gif"});
        }
    }
}