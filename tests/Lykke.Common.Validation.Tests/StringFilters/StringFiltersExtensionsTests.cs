using System;
using FluentAssertions;
using Lykke.Common.Validation.Configuration;
using Lykke.Common.Validation.StringFilters;
using NUnit.Framework;

namespace Lykke.Common.Validation.Tests.StringFilters
{
    public class StringFiltersExtensionsTests
    {
        private static readonly char[] ZeroWidthChars = { '\u0000' , '\u2060', '\u2061' , '\u2062' };

        private const string CleanString = "lorem ipsum";
        private const string StringWithZeroWidthChars = "lor\u0000em\u2060 ips\u2060u\u2062m";
        private const string StringWithLeadingSpaces = "  lorem ipsum\t";
        private const string StringWithUnusualSpaces = "lorem\tipsum";
        private const string StringWithMultipleSpaces = "lorem\t \nipsum";

        private const string StringWithFraudMixes = " \t lor\u0000em\u2060\t \t\n \nips\u2060u\u2062m  \t";


        [Test]
        public void RemoveZeroWidthChars_LykkeValidationNotConfigured_ThrowsException()
        {
            LykkeValidation.Configuration = null;
            var source = StringWithZeroWidthChars;

            Action action = () => source.RemoveZeroWidthChars();

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void RemoveZeroWidthChars_ZeroWidthCharsNotSpecified_ThrowsException()
        {
            LykkeValidation.Configuration = new ValidationConfiguration {ZeroWidthChars = null};
            var source = StringWithZeroWidthChars;

            Action action = () => source.RemoveZeroWidthChars();

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void RemoveZeroWidthChars_CleanStringProvided_ReturnsSourceString()
        {
            LykkeValidation.Configuration = new ValidationConfiguration { ZeroWidthChars = ZeroWidthChars };
            var source = CleanString;

            var result = source.RemoveZeroWidthChars();

            result.Should().Be(source);
        }

        [Test]
        public void RemoveZeroWidthChars_StringWithZeroWidthCharsProvided_ReturnsCleanString()
        {
            LykkeValidation.Configuration = new ValidationConfiguration { ZeroWidthChars = ZeroWidthChars };
            var source = StringWithZeroWidthChars;
            var expected = CleanString;

            var result = source.RemoveZeroWidthChars();

            result.Should().Be(expected);
        }

        [Test]
        public void RemoveIrregularSpaces_CleanStringProvided_ReturnsSourceString()
        {
            var source = CleanString;

            var result = source.RemoveIrregularSpaces();

            result.Should().Be(source);
        }

        [Test]
        public void RemoveIrregularSpaces_StringWithMultipleSpacesProvided_ReturnsCleanString()
        {
            var source = StringWithMultipleSpaces;
            var expected = CleanString;

            var result = source.RemoveIrregularSpaces();

            result.Should().Be(expected);
        }

        [Test]
        public void RemoveIrregularSpaces_StringWithLeadingSpacesProvided_ReturnsCleanString()
        {
            var source = StringWithLeadingSpaces;
            var expected = CleanString;

            var result = source.RemoveIrregularSpaces();

            result.Should().Be(expected);
        }

        [Test]
        public void RemoveIrregularSpaces_StringWithUnusualSpacesProvided_ReturnsCleanString()
        {
            var source = StringWithUnusualSpaces;
            var expected = CleanString;

            var result = source.RemoveIrregularSpaces();

            result.Should().Be(expected);
        }

        [Test]
        public void RemoveFraudMixes_StringWithUnusualSpacesProvided_ReturnsCleanString()
        {
            LykkeValidation.Configuration = new ValidationConfiguration { ZeroWidthChars = ZeroWidthChars };
            var source = StringWithFraudMixes;
            var expected = CleanString;

            var result = source.RemoveFraudMixes();

            result.Should().Be(expected);
        }
    }
}
