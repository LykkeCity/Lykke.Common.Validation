using Lykke.Common.Validation.PasswordHash.Attribute;

namespace Lykke.Common.Validation.Tests.PasswordHash.TestModels
{
    internal class PasswordHashCustomMessageTestModel
    {
        [PasswordHash(ErrorMessage = "{0} With Custom Error Message.")]
        public string PasswordHash { get; set; }
    }
}