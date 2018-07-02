using Lykke.Common.Validation.PasswordHash;

namespace Lykke.Common.Validation.Tests.PasswordHash.TestModels
{
    internal class PasswordHashTestModel
    {
        [PasswordHash] 
        public string PasswordHash { get; set; }
    }
}