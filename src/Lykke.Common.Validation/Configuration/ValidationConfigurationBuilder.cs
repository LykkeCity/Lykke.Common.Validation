using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Lykke.Common.Validation.Configuration
{
    internal class ValidationConfigurationBuilder : IValidationConfigurationExpression
    {
        internal ValidationConfiguration Configuration;

        public ValidationConfigurationBuilder()
        {
            Configuration = new ValidationConfiguration();
        }

        public void SetZeroWidthChars(IEnumerable<char> chars)
        {
            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            AssertBuildIsNotFinished();
            
            Configuration.ZeroWidthChars = ImmutableArray.CreateRange(chars.Distinct());
        }

        public IValidationConfiguration Build()
        {
            AssertBuildIsNotFinished();

            var config = Configuration;
            Configuration = null;

            return config;
        }

        private void AssertBuildIsNotFinished()
        {
            if (Configuration == null)
            {
                throw new InvalidOperationException("Build is already finished");
            }
        }
    }
}
