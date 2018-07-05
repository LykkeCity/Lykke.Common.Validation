using Lykke.Common.Validation.PasswordHash.Attribute;

namespace Lykke.Common.Validation.Tests.PasswordHash.TestModels
{
    internal class PasswordHashTestModel
    {
        [PasswordHash] 
        public string PasswordHash { get; set; }
    }
}