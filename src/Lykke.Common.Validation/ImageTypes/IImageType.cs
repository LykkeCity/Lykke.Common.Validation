using System.Collections.Generic;

namespace Lykke.Common.Validation.ImageTypes
{
    /// <summary>
    ///     Contains information about image extensions and valid byte signatures for them.
    ///     Used to validate files.
    /// </summary>
    public interface IImageType
    {
        /// <summary>
        ///     List of extension supported by image type.
        /// </summary>
        IReadOnlyCollection<string> Extensions { get; }

        /// <summary>
        ///     List of valid signatures supported by image type.
        /// </summary>
        IReadOnlyCollection<byte[]> HexSignatures { get; }
    }
}