using System;
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

            var resultChars = ConfigurationHelpers.UnescapedStringToCharsArray(configString);

            resultChars.Should().BeEquivalentTo(expetedChars);
        }

        [Test]
        public void UnescapedStringToCharsArray_EmptyStringProvided_ReturnsEmptyCharsArray()
        {
            var configString = string.Empty;

            var resultChars = ConfigurationHelpers.UnescapedStringToCharsArray(configString);

            resultChars.Should().BeEmpty();
        }

        [Test]
        public void UnescapedStringToCharsArray_NullProvided_ThrowsException()
        {
            Action action = () => ConfigurationHelpers.UnescapedStringToCharsArray(null);

            action.Should().Throw<ArgumentNullException>();
        }
    }
}
