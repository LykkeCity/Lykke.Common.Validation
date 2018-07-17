using System.IO;
using System.Linq;
using Lykke.Common.Validation.StreamMaxSize;
using Lykke.Common.Validation.Tests.StreamMaxSize.TestData;
using NUnit.Framework;

namespace Lykke.Common.Validation.Tests.StreamMaxSize
{
    public class StreamMaxSizeValidatorTests
    {
        private readonly StreamMaxSizeValidator _validator;

        private readonly long _streamMaxSize = 1;

        public StreamMaxSizeValidatorTests()
        {
            _validator = new StreamMaxSizeValidator(_streamMaxSize);
        }


        [TestCaseSource(typeof(ShortStreamTestData))]
        public void Validate_ShortStream_ReturnTrue(Stream stream)
        {
            // Act
            var result = _validator.Validate(stream);

            // Assert
            Assert.True(result.IsValid);
        }


        [TestCaseSource(typeof(LongStreamTestData))]
        public void Validate_LongStream_ReturnFalse(Stream stream)
        {
            // Act
            var result = _validator.Validate(stream);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual(StreamMaxSizeErrorCode.LongerThanMaxSize, result.ErrorCodes.First());
        }

        [TestCase(null)]
        public void Validate_Null_ReturnFalse(Stream stream)
        {
            // Act
            var result = _validator.Validate(stream);

            // Assert
            Assert.False(result.IsValid);
            Assert.AreEqual(StreamMaxSizeErrorCode.Null, result.ErrorCodes.First());
        }
    }
}