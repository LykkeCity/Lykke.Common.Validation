using FluentAssertions;
using Lykke.Common.Validation.Configuration;
using NUnit.Framework;

namespace Lykke.Common.Validation.Tests.Configuration
{
    public class ConfigurationHelpersTests
    {
        [Test]
        public void UnescapedStringToCharsArray_NotEmptyStringProvided_ReturnsDistinctExpectedCharsArray()
        {
            var configString = @"a\t[\u1337*a";
            var expetedChars = new[] {'a', '\t', '[', '\u1337', '*'};

            var resultChars = configString.UnescapedStringToCharsArray();

            resultChars.Should().BeEquivalentTo(expetedChars);
        }

        [Test]
        public void UnescapedStringToCharsArray_EmptyStringProvided_ReturnsEmptyCharsArray()
        {
            var configString = string.Empty;

            var resultChars = configString.UnescapedStringToCharsArray();

            resultChars.Should().BeEmpty();
        }
    }
}
