namespace Lykke.Common.Validation.ImageTypes
{
    public enum ImageTypeErrorCode
    {
        NullOrEmpty,
        InvalidFileName,
        InvalidExtension,
        FileStreamIsNull,
        FileStreamIsTooShort,
        InvalidHexSignature
    }
}