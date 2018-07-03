using System;
using Microsoft.AspNetCore.Http;

namespace Lykke.Common.Validation.ImageTypes.Attribute
{
    /// <summary>
    ///     Deep recovery selfie image validation, based on <see cref="ImageTypeIFormFileAttribute" />.
    ///     Use only on <see cref="IFormFile" />.
    ///     Extensions could not be passed to this attribute as parameters.
    ///     Valid file extensions: ".jpg", ".jpeg", ".png", ".gif", ".bmp".
    ///     Any other extensions are invalid.
    /// </summary>
    /// <example>
    ///     Example of using with custom error message:
    ///     <c>[RecoverySelfieImageAttribute(ErrorMessage="File {0} should be valid {1} image.")]</c>
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RecoverySelfieImageIFormFileAttribute : ImageTypeIFormFileAttribute
    {
    }
}