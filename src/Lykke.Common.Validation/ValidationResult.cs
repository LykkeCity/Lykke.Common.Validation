using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lykke.Common.Validation
{
    public abstract class ValidationResult<TEnum>
        where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        private readonly List<TEnum> _errorCodes = new List<TEnum>();

        private readonly ArgumentException _argumentException = new ArgumentException("TEnum must be an enum.");

        public bool IsValid => !_errorCodes.Any();

        public IReadOnlyCollection<TEnum> ErrorCodes =>
            new ReadOnlyCollection<TEnum>(_errorCodes);

        protected ValidationResult()
        {
            if (!typeof(TEnum).IsEnum) throw _argumentException;
        }

        protected ValidationResult(TEnum errorCode)
        {
            if (!typeof(TEnum).IsEnum) throw _argumentException;

            _errorCodes.Add(errorCode);
        }

        protected ValidationResult(IEnumerable<TEnum> errorCodes)
        {
            if (!typeof(TEnum).IsEnum) throw _argumentException;

            _errorCodes.AddRange(errorCodes);
        }

        public void Add(TEnum errorCode)
        {
            _errorCodes.Add(errorCode);
        }
    }
}