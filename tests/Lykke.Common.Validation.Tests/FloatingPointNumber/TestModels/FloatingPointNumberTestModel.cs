using Lykke.Common.Validation.FloatingPointNumber.Attribute;

namespace Lykke.Common.Validation.Tests.FloatingPointNumber.TestModels
{
    internal class FloatingPointNumberTestModel
    {
        [FloatingPointNumber] 
        public string Input { get; set; }
    }
}