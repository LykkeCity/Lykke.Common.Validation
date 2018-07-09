using System.Collections.Generic;

namespace Lykke.Common.Validation.ImageTypes
{
    public class ImageTypeValidationResult : ValidationResult<ImageTypeErrorCode>
    {
        public ImageTypeValidationResult()
        {
        }

        public ImageTypeValidationResult(ImageTypeErrorCode errorCode) : base(errorCode)
        {
        }

        protected ImageTypeValidationResult(IEnumerable<ImageTypeErrorCode> errorCodes) :
            base(errorCodes)
        {
        }
    }
}