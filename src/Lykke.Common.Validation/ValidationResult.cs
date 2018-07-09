using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MoreLinq;

namespace Lykke.Common.Validation
{
    /// <summary>
    ///     Base class for validation result.
    /// </summary>
    /// <typeparam name="TEnum">Should be enum. Used for error codes.</typeparam>
    /// <exception cref="ArgumentException">Thrown if <typeparamref name="TEnum" /> is not Enum.</exception>
    public abstract class ValidationResult<TEnum>
        where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        private readonly List<TEnum> _errorCodes = new List<TEnum>();

        private readonly ArgumentException _notEnumArgumentException = new ArgumentException("TEnum must be an enum.");

        /// <summary>
        ///     Indicates if validation is successful.
        /// </summary>
        public bool IsValid => !_errorCodes.Any();

        /// <summary>
        ///     Collection of error codes, returned during validation.
        /// </summary>
        public IReadOnlyCollection<TEnum> ErrorCodes =>
            new ReadOnlyCollection<TEnum>(_errorCodes);

        /// <summary>
        ///     Create successfull result.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if <typeparamref name="TEnum" /> is not Enum.</exception>
        protected ValidationResult()
        {
            IsEnumType();
        }

        /// <summary>
        ///     Create result with error.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if <typeparamref name="TEnum" /> is not Enum.</exception>
        protected ValidationResult(TEnum errorCode) : this()
        {
            Add(errorCode);
        }

        /// <summary>
        ///     Create result with error list.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if <typeparamref name="TEnum" /> is not Enum.</exception>
        protected ValidationResult(IEnumerable<TEnum> errorCodes): this()
        {
            errorCodes.ForEach(Add);
        }

        /// <summary>
        ///     Add error code.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if <typeparamref name="TEnum" /> is not Enum.</exception>
        public void Add(TEnum errorCode)
        {
            IsDefined(errorCode);
            _errorCodes.Add(errorCode);
        }

        private void IsEnumType()
        {
            if (!typeof(TEnum).IsEnum) 
                throw _notEnumArgumentException;
        }

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private void IsDefined(TEnum errorCode)
        {
            if (!Enum.IsDefined(typeof(TEnum), errorCode))
                throw _notEnumArgumentException;
        }
    }
}