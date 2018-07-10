using System.Collections;
using System.Linq;
using Lykke.Common.Validation.Tests.ImageTypes.Helpers;

namespace Lykke.Common.Validation.Tests.ImageTypes.TestData
{
    internal class InvalidFileSignatureTestData : IEnumerable
    {
        private readonly ImageTypeTestDataDto[] _data =
        {
            ImageTypeTestHelper.CreateTestData(".jpg",
                new byte[] {0xFA, 0xD8, 0xFF, 0xDB, 0x00, 0x00, 0x00, 0x00}),
            ImageTypeTestHelper.CreateTestData(".jpeg",
                new byte[] {0xFD, 0xD8, 0xFF, 0xE0, 0x00, 0x00, 0x00, 0x00}),
            ImageTypeTestHelper.CreateTestData(".jpeg",
                new byte[] {0xFC, 0xD8, 0xFF, 0xE1, 0x00, 0x00, 0x00, 0x00}),
            ImageTypeTestHelper.CreateTestData(".png",
                new byte[] {0x79, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A}),
            ImageTypeTestHelper.CreateTestData(".gif",
                new byte[] {0x54, 0x49, 0x46, 0x38, 0x37, 0x61, 0x00, 0x00}),
            ImageTypeTestHelper.CreateTestData(".gif",
                new byte[] {0x55, 0x49, 0x46, 0x38, 0x39, 0x61, 0x00, 0x00}),
            ImageTypeTestHelper.CreateTestData(".bmp",
                new byte[] {0x56, 0x4D, 0x56, 0x1A, 0x1B, 0x00, 0x00, 0x00})
        };

        public IEnumerator GetEnumerator()
        {
            return _data.Select(s => new object[] {s}).GetEnumerator();
        }
    }
}