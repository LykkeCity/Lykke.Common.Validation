using System.Collections;

namespace Lykke.Common.Validation.Tests.NoSpecialCharacters.TestData
{
    internal class WithSpecialCharactersTestData : IEnumerable
    {
        private static readonly char[] RestrictedCharacters =
        {
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '_', '=', ':', ';', '.', ',', '"', '\'', '\\',
            '/', '|', '?', '<', '>', '~', '[', ']', '{', '}', '`'
        };

        public IEnumerator GetEnumerator()
        {
            foreach (var s in RestrictedCharacters) yield return new object[] {s.ToString()};

            yield return new object[] {"SELECT * FROM Production.Product ORDER BY Name ASC;"};
            yield return new object[] {"<script>alert(\'Injected!\');</script>"};
        }
    }
}