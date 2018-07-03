using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lykke.Common.Validation.ImageTypes
{
    public class JpgImageType : IImageType
    {
        private static readonly string[] ExtensionList = {".jpg", ".jpeg"};

        private static readonly byte[][] HexSignatureList =
        {
            new byte[] {0xFF, 0xD8, 0xFF, 0xDB},
            new byte[] {0xFF, 0xD8, 0xFF, 0xE0},
            new byte[] {0xFF, 0xD8, 0xFF, 0xE1}
        };

        public IReadOnlyCollection<string> Extensions { get; } = new ReadOnlyCollection<string>(ExtensionList);

        public IReadOnlyCollection<byte[]> HexSignatures { get; } = new ReadOnlyCollection<byte[]>(HexSignatureList);
    }
}