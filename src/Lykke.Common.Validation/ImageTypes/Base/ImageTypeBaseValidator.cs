using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lykke.Common.Validation.ImageTypes.Attribute;
using Lykke.Common.Validation.ImageTypes.Fluent;

namespace Lykke.Common.Validation.ImageTypes.Base
{
    /// <summary>
    ///     This class contains common logic to use inside Lykke.Common.Validation package only.
    ///     If you need new Validator for your needs, create a wrapper around this class and use it.
    ///     Base class to perform image type validation.
    /// </summary>
    /// <example>
    ///     Attribute wrapper: <see cref="ImageTypeIFormFileAttribute" />.
    ///     Fluent validator wrapper: <see cref="ImageTypeIFormFileValidator" />.
    /// </example>
    internal class ImageTypeBaseValidator
    {
        public string AllowedExtensions { get; }

        private static readonly IEnumerable<IImageType> DefaultImageTypesList = new IImageType[]
        {
            new JpgImageType(),
            new PngImageType(),
            new GifImageType(),
            new BmpImageType()
        };

        private static readonly IDictionary<string, IImageType> DefaultImageTypes = InitDefaultImageTypes();

        private readonly IDictionary<string, IImageType> _imageTypes = new Dictionary<string, IImageType>();

        public ImageTypeBaseValidator(params string[] imageExtensions)
        {
            if (imageExtensions == null || imageExtensions.Length == 0)
                _imageTypes = DefaultImageTypes;
            else
                foreach (var extension in imageExtensions)
                    if (!string.IsNullOrWhiteSpace(extension) &&
                        DefaultImageTypes.TryGetValue(extension, out var imageType))
                        _imageTypes.Add(extension, imageType);

            AllowedExtensions = string.Join(", ", _imageTypes.Keys);

        }

        public bool IsValid(string fileName, Stream fileStream)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            var extension = GetExtension(fileName);

            if (string.IsNullOrEmpty(extension) || !_imageTypes.TryGetValue(extension, out var imageType))
                return false;

            if (fileStream == null || fileStream == Stream.Null)
                return false;

            using (fileStream)
            {
                var longestSignature = imageType.HexSignatures.OrderByDescending(x => x.Length).First();

                if(fileStream.Length < longestSignature.Length)
                    return false;

                var buffer = new byte [longestSignature.Length];
                fileStream.Read(buffer, 0, buffer.Length);

                if (!ValidateSignature(buffer, imageType.HexSignatures))
                    return false;

                return true;
            }
        }

        private static bool ValidateSignature(byte[] file, IEnumerable<byte[]> validHexSignatures)
        {
            if (file == null || validHexSignatures == null)
                return false;

            return validHexSignatures
                .Any(byteSequence => file.Take(byteSequence.Length)
                    .SequenceEqual(byteSequence));
        }

        private static string GetExtension(string fileName)
        {
            return string.IsNullOrWhiteSpace(fileName) ? string.Empty : Path.GetExtension(fileName);
        }

        private static IDictionary<string, IImageType> InitDefaultImageTypes()
        {
            var defaultImageTypes = new Dictionary<string, IImageType>();

            foreach (var imageType in DefaultImageTypesList)
            foreach (var extension in imageType.Extensions)
                defaultImageTypes.Add(extension, imageType);

            return defaultImageTypes;
        }
    }
}