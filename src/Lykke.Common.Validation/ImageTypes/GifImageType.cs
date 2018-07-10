using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lykke.Common.Validation.ImageTypes
{
    /// <summary>
    ///     Class representing Gif image type.
    /// </summary>
    public class GifImageType : IImageType
    {
        private static readonly string[] ExtensionList = {".gif"};

        private static readonly byte[][] HexSignatureList =
        {
            new byte[] {0x47, 0x49, 0x46, 0x38, 0x37, 0x61},
            new byte[] {0x47, 0x49, 0x46, 0x38, 0x39, 0x61}
        };

        /// <inheritdoc />
        public IReadOnlyCollection<string> Extensions { get; } = new ReadOnlyCollection<string>(ExtensionList);

        /// <inheritdoc />
        public IReadOnlyCollection<byte[]> HexSignatures { get; } = new ReadOnlyCollection<byte[]>(HexSignatureList);
    }
}