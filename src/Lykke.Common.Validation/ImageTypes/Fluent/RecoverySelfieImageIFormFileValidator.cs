using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Lykke.Common.Validation.ImageTypes.Fluent
{
    /// <summary>
    ///     Deep recovery selfie image validator, based on <see cref="ImageTypeIFormFileValidator" />.
    ///     Use only on <see cref="IFormFile"/>.
    ///     Extensions could not be passed to this validator as parameters.
    ///     Valid file extensions: ".jpg", ".jpeg", ".png", ".gif", ".bmp".
    ///     Any other extensions are invalid.
    /// </summary>
    public class RecoverySelfieImageIFormFileValidator : ImageTypeIFormFileValidator
    {
        public RecoverySelfieImageIFormFileValidator() : base(".jpg", ".jpeg", ".png", ".gif", ".bmp")
        {
        }
    }
}

