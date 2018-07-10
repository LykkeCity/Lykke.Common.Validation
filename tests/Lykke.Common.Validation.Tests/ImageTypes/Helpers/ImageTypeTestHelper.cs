using System.IO;
using Lykke.Common.Validation.Tests.ImageTypes.TestData;
using Microsoft.AspNetCore.Http.Internal;

namespace Lykke.Common.Validation.Tests.ImageTypes.Helpers
{
    internal static class ImageTypeTestHelper
    {
        public static ImageTypeTestDataDto CreateTestData(string extension, byte[] signature)
        {
            var name = $"Test{extension}";

            var stream = new MemoryStream(signature);

            return new ImageTypeTestDataDto
            {
                File = new FormFile(stream, 0, signature.Length, name, name),
                Stream = stream,
            };
        }
    }
}