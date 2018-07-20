using System;
using System.Linq;
using FluentAssertions;
using Lykke.Common.Validation.Configuration;
using Lykke.Common.Validation.InputConvertors;
using NUnit.Framework;

namespace Lykke.Common.Validation.Tests.InputConvertors
{
    public class InputStringConvertorsTests
    {
        private static readonly char[] ZeroWidthChars = { '\u0000' , '\u2060', '\u2061' , '\u2062', '\u2060' };

        private const string CleanString = "lorem ipsum";
        private const string StringWithZeroWidthChars = "lor\u0000em\u2060 ips\u2060u\u2062m";
        private const string StringWithLeadingSpaces = "  lorem ipsum\t";
        private const string StringWithUnusualSpaces = "lorem\tipsum";
        private const string StringWithMultipleSpaces = "lorem\t \nipsum";

        private const string StringWithFraudMixes = " \t lor\u0000em\u2060\t \t\n \nips\u2060u\u2062m  \t";


        [Test]
        public void NoArgumentConstructor_LykkeValidationNotConfigured_ThrowsException()
        {
            LykkeValidation.Configuration = null;

            Action action = () => new InputStringConvertors();

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void NoArgumentConstructor_ZeroWidthCharsNotSpecified_ThrowsException()
        {
            LykkeValidation.Configuration = new ValidationConfiguration {ZeroWidthChars = null};

            Action action = () => new InputStringConvertors();

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void ArgumentedConstructor_NullProvided_ThrowsException()
        {
            LykkeValidation.Configuration = null;

            Action action = () => new InputStringConvertors(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void NoArgumentConstructor_ZeroWidthCharsSpecified_ObjectInitializedCorrectly()
        {
            LykkeValidation.Configuration = new ValidationConfiguration { ZeroWidthChars = ZeroWidthChars };

            var subject = new InputStringConvertors();

            subject.ZeroWidthChars.Should().BeEquivalentTo(ZeroWidthChars.Distinct());
        }

        [Test]
        public void ArgumentedConstructor_ZeroWidthCharsProvided_ObjectInitializedCorrectly()
        {
            LykkeValidation.Configuration = null;

            var subject = new InputStringConvertors(ZeroWidthChars);

            subject.ZeroWidthChars.Should().BeEquivalentTo(ZeroWidthChars.Distinct());
        }

        [Test]
        public void RemoveZeroWidthChars_StringWithZeroWidthCharsProvided_ReturnsCleanString()
        {
            var source = StringWithZeroWidthChars;
            var expected = CleanString;
            var subject = new InputStringConvertors(ZeroWidthChars);

            var result = subject.RemoveZeroWidthChars(source);

            result.Should().Be(expected);
        }

        [Test]
        public void FixIrregularSpaces_StringWithMultipleSpacesProvided_ReturnsCleanString()
        {
            var source = StringWithMultipleSpaces;
            var expected = CleanString;
            var subject = new InputStringConvertors(ZeroWidthChars);

            var result = subject.FixIrregularSpaces(source);

            result.Should().Be(expected);
        }

        [Test]
        public void FixIrregularSpaces_StringWithLeadingSpacesProvided_ReturnsCleanString()
        {
            var source = StringWithLeadingSpaces;
            var expected = CleanString;
            var subject = new InputStringConvertors(ZeroWidthChars);

            var result = subject.FixIrregularSpaces(source);

            result.Should().Be(expected);
        }

        [Test]
        public void FixIrregularSpaces_StringWithUnusualSpacesProvided_ReturnsCleanString()
        {
            var source = StringWithUnusualSpaces;
            var expected = CleanString;
            var subject = new InputStringConvertors(ZeroWidthChars);

            var result = subject.FixIrregularSpaces(source);

            result.Should().Be(expected);
        }

        [Test]
        public void FixFraudMixes_StringWithUnusualSpacesProvided_ReturnsCleanString()
        {
            var source = StringWithFraudMixes;
            var expected = CleanString;
            var subject = new InputStringConvertors(ZeroWidthChars);

            var result = subject.FixFraudMixes(source);

            result.Should().Be(expected);
        }

        [Test]
        public void RemoveZeroWidthChars_CleanStringProvided_ReturnsSourceString()
        {
            var source = CleanString;
            var subject = new InputStringConvertors(ZeroWidthChars);

            var result = subject.RemoveZeroWidthChars(source);

            result.Should().Be(source);
        }

        [Test]
        public void FixIrregularSpaces_CleanStringProvided_ReturnsSourceString()
        {
            var source = CleanString;
            var subject = new InputStringConvertors(ZeroWidthChars);

            var result = subject.FixIrregularSpaces(source);

            result.Should().Be(source);
        }

        [Test]
        public void FixFraudMixes_CleanStringProvided_ReturnsSourceString()
        {
            var source = CleanString;
            var subject = new InputStringConvertors(ZeroWidthChars);

            var result = subject.FixFraudMixes(source);

            result.Should().Be(source);
        }

        [Test]
        public void RemoveZeroWidthChars_NullProvided_ThrowsException()
        {
            var subject = new InputStringConvertors(ZeroWidthChars);

            Action action = () => subject.RemoveZeroWidthChars(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void FixIrregularSpaces_NullProvided_ThrowsException()
        {
            var subject = new InputStringConvertors(ZeroWidthChars);

            Action action = () => subject.FixIrregularSpaces(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void FixFraudMixes_NullProvided_ThrowsException()
        {
            var subject = new InputStringConvertors(ZeroWidthChars);

            Action action = () => subject.FixFraudMixes(null);

            action.Should().Throw<ArgumentNullException>();
        }
    }
}
