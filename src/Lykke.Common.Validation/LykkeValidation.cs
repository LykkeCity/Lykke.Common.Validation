using System;
using Lykke.Common.Validation.Configuration;

namespace Lykke.Common.Validation
{
    /// <summary>
    /// Provides static methods to operate with LykkeValidation configuration
    /// </summary>
    public static class LykkeValidation
    {
        private static bool _isInitialized;

        /// <summary>Initialize static configuration instance</summary>
        /// <param name="configAction"></param>
        public static void Initialize(Action<IValidationConfigurationExpression> configAction)
        {
            if (_isInitialized)
            {
                throw new InvalidOperationException($"{nameof(LykkeValidation)} is already initialized");
            }

            var builder = new ValidationConfigurationBuilder();
            configAction.Invoke(builder);
            Configuration = builder.Build();

            _isInitialized = true;
        }

        /// <summary>Static configuration for performing validation</summary>
        public static IValidationConfiguration Configuration { get; internal set; }
    }
}
