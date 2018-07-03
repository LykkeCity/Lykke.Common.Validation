using System.IO;
using Microsoft.AspNetCore.Http.Internal;
using Xunit;

namespace Lykke.Common.Validation.Tests.ImageTypes.TestData
{
    internal class InvalidFileExtensionTestData : TheoryData<ImageTypeTestDataDto>
    {
        public InvalidFileExtensionTestData()
        {
            var dto = new ImageTypeTestDataDto
            {
                File = new FormFile(Stream.Null, 0, 0, "Test.exe", "Test.exe")
            };
            Add(dto);
        }
    }
}