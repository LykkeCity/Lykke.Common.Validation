using FluentValidation;
using Lykke.Common.Validation.ImageTypes;
using Lykke.Common.Validation.ImageTypes.Fluent;
using Lykke.Common.Validation.Tests.ImageTypes.TestModels;

namespace Lykke.Common.Validation.Tests.ImageTypes.Fluent
{
    /// <summary>
    ///     Example of using fluent validator
    /// </summary>
    internal class ImageTypeIFormFileTestValidator : AbstractValidator<ImageTypeIFormFileTestModel>
    {
        public ImageTypeIFormFileTestValidator()
        {
            RuleFor(model => model.File)
                .SetValidator(new ImageTypeIFormFileValidator(".jpg", ".jpeg", ".png", ".gif", ".bmp"));
        }
    }
}