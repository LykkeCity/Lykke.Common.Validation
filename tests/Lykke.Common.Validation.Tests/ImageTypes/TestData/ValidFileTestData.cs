using Lykke.Common.Validation.Tests.ImageTypes.Helpers;
using Xunit;

namespace Lykke.Common.Validation.Tests.ImageTypes.TestData
{
    internal class ValidFileTestData : TheoryData<ImageTypeTestDataDto>
    {
        public ValidFileTestData()
        {
            Add(ImageTypeTestHelper.CreateTestData(".jpg",
                new byte[] {0xFF, 0xD8, 0xFF, 0xDB, 0x00, 0x00, 0x00, 0x00}));
            Add(ImageTypeTestHelper.CreateTestData(".jpeg",
                new byte[] {0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x00, 0x00, 0x00}));
            Add(ImageTypeTestHelper.CreateTestData(".jpeg",
                new byte[] {0xFF, 0xD8, 0xFF, 0xE1, 0x00, 0x00, 0x00, 0x00}));
            Add(ImageTypeTestHelper.CreateTestData(".png",
                new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A}));
            Add(ImageTypeTestHelper.CreateTestData(".gif",
                new byte[] {0x47, 0x49, 0x46, 0x38, 0x37, 0x61, 0x00, 0x00}));
            Add(ImageTypeTestHelper.CreateTestData(".gif",
                new byte[] {0x47, 0x49, 0x46, 0x38, 0x39, 0x61, 0x00, 0x00}));
            Add(ImageTypeTestHelper.CreateTestData(".bmp",
                new byte[] {0x42, 0x4D, 0x56, 0x1A, 0x1B, 0x00, 0x00, 0x00}));
        }
    }
}