using System;
using Lykke.Common.Validation.Configuration;

namespace Lykke.Common.Validation
{
    /// <summary> Provides static methods to operate with LykkeValidation configuration </summary>
    public static class LykkeValidation
    {
        /// <summary> Initialize static configuration instance </summary>
        public static void Initialize(Action<IValidationConfigurationExpression> configAction)
        {
            if (configAction == null)
            {
                throw new ArgumentNullException(nameof(configAction));
            }

            if (Configuration != null)
            {
                throw new InvalidOperationException($"{nameof(LykkeValidation)} is already initialized");
            }

            var builder = new ValidationConfigurationBuilder();
            configAction.Invoke(builder);
            Configuration = builder.Build();
        }

        /// <summary> Static configuration for performing validation </summary>
        public static IValidationConfiguration Configuration { get; internal set; }
    }
}
