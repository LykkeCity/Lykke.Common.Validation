using System.IO;
using Microsoft.AspNetCore.Http;

namespace Lykke.Common.Validation.Tests.ImageTypes.TestData
{
    public class ImageTypeTestDataDto
    {
        public IFormFile File { get; set; }
        public Stream Stream { get; set; }
    }
}