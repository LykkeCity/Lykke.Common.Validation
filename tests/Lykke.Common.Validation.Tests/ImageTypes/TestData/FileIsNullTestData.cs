using Xunit;

namespace Lykke.Common.Validation.Tests.ImageTypes.TestData
{
    internal class FileIsNullTestData : TheoryData<ImageTypeTestDataDto>
    {
        public FileIsNullTestData()
        {
            var dto = new ImageTypeTestDataDto
            {
                File = null
            };
            Add(dto);
        }
    }
}