using Lykke.Common.Validation.ImageTypes.Attribute;
using Microsoft.AspNetCore.Http;

namespace Lykke.Common.Validation.Tests.ImageTypes.TestModels
{
    internal class ImageTypeIFormFileCustomMessageTestModel
    {
        [ImageTypeIFormFile(".jpg", ErrorMessage = "{0} is not a {1} image.")]
        public IFormFile File { get; set; }
    }
}