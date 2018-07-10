using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lykke.Common.Validation.ImageTypes
{
    /// <summary>
    ///     Class representing Bmp image type.
    /// </summary>
    public class BmpImageType : IImageType
    {
        private static readonly string[] ExtensionList = {".bmp"};

        private static readonly byte[][] HexSignatureList =
        {
            new byte[] {0x42, 0x4D}
        };

        /// <inheritdoc />
        public IReadOnlyCollection<string> Extensions { get; } = new ReadOnlyCollection<string>(ExtensionList);

        /// <inheritdoc />
        public IReadOnlyCollection<byte[]> HexSignatures { get; } = new ReadOnlyCollection<byte[]>(HexSignatureList);
    }
}