using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lykke.Common.Validation.ImageTypes
{
    public class PngImageType : IImageType
    {
        private static readonly string[] ExtensionList = {".png"};

        private static readonly byte[][] HexSignatureList =
        {
            new byte[] {0x89, 0x50, 0x4E, 0x47}
        };

        public IReadOnlyCollection<string> Extensions { get; } = new ReadOnlyCollection<string>(ExtensionList);

        public IReadOnlyCollection<byte[]> HexSignatures { get; } = new ReadOnlyCollection<byte[]>(HexSignatureList);
    }
}