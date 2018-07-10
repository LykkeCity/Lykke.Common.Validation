using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lykke.Common.Validation.ImageTypes
{
    /// <summary>
    ///     Class representing Png image type.
    /// </summary>
    public class PngImageType : IImageType
    {
        private static readonly string[] ExtensionList = {".png"};

        private static readonly byte[][] HexSignatureList =
        {
            new byte[] {0x89, 0x50, 0x4E, 0x47}
        };
        
        /// <inheritdoc />
        public IReadOnlyCollection<string> Extensions { get; } = new ReadOnlyCollection<string>(ExtensionList);
        
        /// <inheritdoc />
        public IReadOnlyCollection<byte[]> HexSignatures { get; } = new ReadOnlyCollection<byte[]>(HexSignatureList);
    }
}