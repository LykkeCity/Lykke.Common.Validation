using System.Collections.Generic;

namespace Lykke.Common.Validation.ImageTypes
{
    public interface IImageType
    {
        IReadOnlyCollection<string> Extensions { get; }

        IReadOnlyCollection<byte[]> HexSignatures { get; }
    }
}