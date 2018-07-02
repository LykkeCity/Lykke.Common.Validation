using FluentValidation.TestHelper;
using Lykke.Common.Validation.Tests.PasswordHash.TestData;
using Xunit;

namespace Lykke.Common.Validation.Tests.PasswordHash.FluentValidation
{
    public class PasswordHashFluentValidatorTests
    {
        private readonly PasswordHashValidator _validator;

        public PasswordHashFluentValidatorTests()
        {
            _validator = new PasswordHashValidator();
        }

        [Theory]
        [ClassData(typeof(PasswordHashInvalidTestData))]
        public void Should_Be_Invalid(string passwordHash)
        {
            // Assert
            _validator.ShouldHaveValidationErrorFor(model => model.PasswordHash, passwordHash);
        }

        [Theory]
        [ClassData(typeof(PasswordHashValidTestData))]
        public void Should_Be_Valid(string passwordHash)
        {
            // Assert
            _validator.ShouldNotHaveValidationErrorFor(model => model.PasswordHash, passwordHash);
        }
    }
}