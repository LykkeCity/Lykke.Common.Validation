using Lykke.Common.Validation.ImageTypes.Attribute;
using Microsoft.AspNetCore.Http;

namespace Lykke.Common.Validation.Tests.ImageTypes.TestModels
{
    internal class ImageTypeIFormFileTestModel
    {
        [ImageTypeIFormFile(".jpg", ".jpeg", ".png", ".gif", ".bmp")]
        public IFormFile File { get; set; }
    }
}