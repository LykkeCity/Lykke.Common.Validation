using System;
using System.Linq;
using FluentAssertions;
using Lykke.Common.Validation.Configuration;
using NUnit.Framework;

namespace Lykke.Common.Validation.Tests.Configuration
{
    public class ValidationConfigurationBuilderTests
    {
        private readonly char[] _sampleCharCollection = { '@', 'a', '\u0514', 'a' , '@' };

        [Test]
        public void Build_ConfigurationMethodsNotCalled_ReturnsDefaultConfiguration()
        {
            var subject = new ValidationConfigurationBuilder();
            var defaultConfig = subject.Configuration;

            var config = subject.Build();

            config.Should().BeSameAs(defaultConfig);
        }

        [Test]
        public void Build_BuildCalled_ThrowsException()
        {
            var subject = new ValidationConfigurationBuilder();
            subject.Build();

            Action action = () => subject.Build();

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void SetZeroWidthChars_ConfigurationMethodsNotCalled_SetsDistinctEquivalentCollction()
        {
            var subject = new ValidationConfigurationBuilder();
            var sourceCollection = _sampleCharCollection;
            var distinctSourceCollection = sourceCollection.Distinct().ToArray();

            subject.SetZeroWidthChars(sourceCollection);

            subject.Configuration.ZeroWidthChars.Should().BeEquivalentTo(distinctSourceCollection);
        }

        [Test]
        public void SetZeroWidthChars_BuildCalled_ThrowsException()
        {
            var subject = new ValidationConfigurationBuilder();
            subject.Build();

            Action action = () => subject.SetZeroWidthChars(_sampleCharCollection);

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
