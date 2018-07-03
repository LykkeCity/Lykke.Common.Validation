using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lykke.Common.Validation.ImageTypes
{
    public class GifImageType : IImageType
    {
        private static readonly string[] ExtensionList = {".gif"};

        private static readonly byte[][] HexSignatureList =
        {
            new byte[] {0x47, 0x49, 0x46, 0x38, 0x37, 0x61},
            new byte[] {0x47, 0x49, 0x46, 0x38, 0x39, 0x61}
        };

        public IReadOnlyCollection<string> Extensions { get; } = new ReadOnlyCollection<string>(ExtensionList);

        public IReadOnlyCollection<byte[]> HexSignatures { get; } = new ReadOnlyCollection<byte[]>(HexSignatureList);
    }
}