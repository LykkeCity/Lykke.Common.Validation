using Lykke.Common.Validation.PasswordHash.Base;
using Lykke.Common.Validation.Tests.CommonTestData;
using Lykke.Common.Validation.Tests.PasswordHash.TestData;
using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash.Base
{
    public class PasswordHashBaseValidatorTests
    {
        private readonly PasswordHashBaseValidator _baseValidator;

        public PasswordHashBaseValidatorTests()
        {
            _baseValidator = new PasswordHashBaseValidator();
        }

        [Theory]
        [ClassData(typeof(HashIsValidSha256TestData))]
        public void IsValid_HashIsValidSHA256Hash_ReturnTrue(string passwordHash)
        {
            Assert.True(_baseValidator.IsValid(passwordHash));
        }

        [Theory]
        [ClassData(typeof(HashIsInvalidTestData))]
        public void IsValid_HashIsNotSHA256_ReturnFalse(string passwordHash)
        {
            Assert.False(_baseValidator.IsValid(passwordHash));
        }        
        
        [Theory]
        [ClassData(typeof(NullOrEmptyStringTestData))]
        public void IsValid_NullOrEmpty_ReturnFalse(string passwordHash)
        {
            Assert.False(_baseValidator.IsValid(passwordHash));
        }
    }
}