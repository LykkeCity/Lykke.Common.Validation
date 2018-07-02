using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lykke.Common.Validation.Tests.Helpers
{
    internal static class AttributeTestModelHelper
    {
        public static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, results, true);
            if (model is IValidatableObject o) o.Validate(validationContext);
            return results;
        }
    }
}