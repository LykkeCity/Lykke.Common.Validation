using MoreLinq;
using Xunit;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData
{
    internal class WithSpecialCharacters : TheoryData<string>
    {
        private static readonly char[] RestrictedCharacters = 
        {
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '_', '=', ':', ';', '.', ',', '"', '\'', '\\',
            '/', '|', '?', '<', '>', '~', '[', ']', '{', '}', '`'
        };

        public WithSpecialCharacters()
        {
            RestrictedCharacters.ForEach(c => Add(c.ToString()));
            Add("SELECT * FROM Production.Product ORDER BY Name ASC;");
            Add("<script>alert(\'Injected!\');</script>");
        }
    }
}