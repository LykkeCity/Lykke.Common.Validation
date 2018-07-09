using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lykke.Common.Validation.ImageTypes
{
    /// <summary>
    ///     Validates file is an image.
    /// </summary>
    public class ImageTypeValidator
    {
        /// <summary>
        ///     Allowed file extensins, configured for validator.
        ///     It is a string, containing extensions, separated by comma.
        /// </summary>
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

        /// <summary>
        ///     Create validator for image extension and byte signature.
        /// </summary>
        /// <param name="imageExtensions">
        ///     List of valid file types.
        ///     Available extensions:
        ///     ".jpg", ".jpeg", ".png", ".gif", ".bmp"
        ///     Any other types will be ignored.
        /// </param>
        public ImageTypeValidator(params string[] imageExtensions)
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

        /// <summary>
        ///     Validates file extension and signature.
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="fileStream">File stream data.</param>
        /// <returns>
        ///     If <paramref name="fileName" /> extension is in valid extension provided to constructor.
        ///     And <paramref name="fileStream" /> first bytes match valid bytes for provided file type, based on extension.
        ///     <see cref="ImageTypeValidationResult" /> does not contain any <see cref="ImageTypeErrorCode" /> errors.
        /// </returns>
        public ImageTypeValidationResult Validate(string fileName, Stream fileStream)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return new ImageTypeValidationResult(ImageTypeErrorCode.FileNameNullOrWhitespace);

            var extension = GetExtension(fileName);

            if (string.IsNullOrEmpty(extension) || !_imageTypes.TryGetValue(extension, out var imageType))
                return new ImageTypeValidationResult(ImageTypeErrorCode.FileExtensionEmptyOrInvalid);

            if (fileStream == null || fileStream == Stream.Null)
                return new ImageTypeValidationResult(ImageTypeErrorCode.FileStreamIsNull);

            using (fileStream)
            {
                var longestSignature = imageType.HexSignatures.OrderByDescending(x => x.Length).First();

                if (fileStream.Length < longestSignature.Length)
                    return new ImageTypeValidationResult(ImageTypeErrorCode.FileStreamIsTooShort);

                var buffer = new byte [longestSignature.Length];
                fileStream.Read(buffer, 0, buffer.Length);

                if (!ValidateSignature(buffer, imageType.HexSignatures))
                    return new ImageTypeValidationResult(ImageTypeErrorCode.InvalidHexSignature);

                return new ImageTypeValidationResult();
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