# Lykke.Common.Validation
Contains common validation logic, that could be used in other projects.

# Project structure

## Lykke.Common.Validation

**Lykke.Common.Validation** project contains all validators. If you want to add your own validator, you can create a new folder there. 

### ValidationResult

**ValidationResult** is a generic class that provides basic functionality to return a validation result and its context.
Each validator folder provides an implementation of this class with specific context and error codes (Read about it 
* ```<TEnum>``` - Is a generic type for Enum. To create custom validation result for the specific validator, inherit a new class from **ValidationResult** and provide Enum of possible error cases as **TEnum**.

To help validation localization we decided to return a list of error codes, which are a simple enum. 
For example ```PasswordHashValidator``` returns ```PasswordHashValidationResult```, which has 2 possible error codes: 
```cs
/// <summary>
///     <see cref="PasswordHashValidationResult"/> error codes.
/// </summary>
public enum PasswordHashErrorCode
{
    /// <summary>
    ///     Input is null or empty string.
    /// </summary>
    NullOrEmpty,

    /// <summary>
    ///     Input is not a SHA-256 hash.
    /// </summary>
    NotSha256
}
```
This enum is than passed as ```<TEnum>``` to construct ```PasswordHashValidationResult```.
```cs
public class PasswordHashValidationResult : ValidationResult<PasswordHashErrorCode>
```

See below why do we need this, and how we can use this approach to localize error messages, based on validation result error codes.

* ```ErrorCodes``` - is a list of all error cases happened during the validation process. If this list is empty, it means validation succeeded. ```IsValid``` property 
* ```IsValid``` - indicates validation result. ```True``` when validation process succeeded.

Concrete ValidationResult implementation could also have context public members, which could be useful for constructing localized error messages.

For example ```ImageTypeValidationResult``` has ```AllowedExtensions``` property:
```cs
/// <summary>
/// List of file allowed extensions.
/// </summary>
public string AllowedExtensions { get; internal set; }
```

As the summary explains, this property contains a string with valid extensions passed to ```ImageTypeValidator```.
You can access this field like:
```cs
var result = validator.Validate("ExampleFile.png", fileStream);
// In Phrases.resx: Phrases.FileInvalidExtension = "File extension is invalid! Valid file extensions are: {0}"
var localizedError = string.Format(Phrases.FileInvalidExtension, result.AllowedExtensions);
return localizedError;
```

## Lykke.Common.Validation.Tests
This project contains tests for **Lykke.Common.Validation**. Please, note that **NUnit** framework is used for tests, so for your tests use it too.


## Creating new validator styleguide:
1. Create new folder for your valdiator. **\<ValidatorName\>**
2. Create empty enum **\<ValidatorName\>ErrorCode**
3. Create validation result class 
```csharp
<ValidatorName>ValidationResult : ValidationResult<ValidatorNameErrorCode>
```
Add any public methods to it, they could be filled during validation process. Later calling code can access them to retrieve validation context information. (Described above).

4. Create validator class **\<ValidatorName\>Validator**
5. Create **Validate** method, which should return created  **\<ValidatorName\>ValidationResult**. Parameters for this method could be any of your choice.
6. Create folder in unit tests project: **Lykke.Common.Validation.Tests** / **\<ValidatorName\>**

# Available validators

## FloatingPointNumberValidator
Validates string is a floating point number.

### Example
```cs
var validator = new FloatingPointNumberValidator();
var result = validator.Validate("-123.35");
if (result.IsValid)
  {  ...  }
```

## PasswordHashValidator
Validates string is a valid SHA-256 hash.

### Example
```cs
var validator = new PasswordHashValidator();
var result = validator.Validate("Your pasword hash");
if (result.IsValid)
  {  ...  }
```

## NoSpecialCharactersValidator
Validates string does not contain special characters:
!@#$%^&amp;*()-_=+:;.,"'\/?&lt;&gt;|~[]{}`

### Example
```cs
var validator = new NoSpecialCharactersValidator();
var result = validator.Validate("<script>alert(\'Injected!\');</script>");
if (result.IsValid)
  {  ...  }
```

## ImageTypeValidator
Validates file is an image.

### Example
```cs
var allowedExtensions = new string[] {".bmp", ".jpeg", ".gif"};
var validator = new ImageTypeValidator(allowedExtensions);
// Or var validator = new ImageTypeValidator(".bmp", ".jpeg", ".gif");
var result = validator.Validate("ExampleFile.png", fileStream);
if (result.IsValid)
  {  ...  }
```

# Localization and usage

## Example of Attribute
```cs
// This is example of using ImageTypeValidator with DataAnnotations attributes.
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class ImageTypeIFormFileAttribute : ValidationAttribute
{
    // Mapping validator error codes to phrases.
    // Alternatively you could do this with switch/case.
    private readonly Dictionary<ImageTypeErrorCode, string> _errorCodesToMessages =
        new Dictionary<ImageTypeErrorCode, string>
        {
            {ImageTypeErrorCode.FileStreamIsNull, Phrases.ImageTypeValidatorFileStreamIsNull},
            {ImageTypeErrorCode.FileExtensionEmptyOrInvalid, Phrases.ImageTypeValidatorFileExtensionEmptyOrInvalid},
            {ImageTypeErrorCode.InvalidHexSignature, Phrases.ImageTypeValidatorInvalidHexSignature}
            // Other mappings... You should provide error phrases for all possible Error codes.
        };

    private readonly ImageTypeValidator _validator;

    // A Default error message, you could use another approach, it here just for example.
    private readonly string _defaultErrorMessage = "File {0} is invalid!";

    public ImageTypeIFormFileAttribute(params string[] imageExtensions)
    {
        _validator = new ImageTypeValidator(imageExtensions);
    }

    // ValidationResult in this context is - System.ComponentModel.DataAnnotations.ValidationResult
    protected override ValidationResult IsValid(object value,
        ValidationContext validationContext)
    {
        var displayName = validationContext.DisplayName;

        var defaultErrorResult = new ValidationResult(string.Format(_defaultErrorMessage, displayName));

        var successResult = ValidationResult.Success;

        if (!(value is IFormFile file))
            return defaultErrorResult;

        using (var fileStream = file.OpenReadStream())
        {
            var validationResult = _validator.Validate(file.FileName, fileStream);

            if (validationResult.IsValid) 
                return successResult;

            var errorCode = validationResult.ErrorCodes.First();

            var errorPhrase = "";

            // Get phrase by error code.
            if (!_errorCodesToMessages.TryGetValue(errorCode, out errorPhrase))
                return defaultErrorResult;

            // Get localized error phrase and insert data into it.
            // Note validationResult.AllowedExtensions is used to provide
            // comma separated list of allowed extensions into error message.
            var errorMessage = string.Format(errorPhrase, displayName, validationResult.AllowedExtensions);

            return new ValidationResult(errorMessage);
        }
    }
}
```

## Example of Attribute usage
```cs
internal class ImageRequestModel
{
    [ImageTypeIFormFile(".jpg", ".jpeg", ".png")]
    public IFormFile File { get; set; }
}
```
