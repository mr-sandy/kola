namespace Unit.Tests.Extensions.EnumerableExtensions.IncrementLast
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Kola.Domain.Extensions;

    using NUnit.Framework;

    public class WhenIncrementingLastOfShortList
    {
        private IEnumerable<int> result;

        [SetUp]
        public void EstablishContext()
        {
            var list = new[] { 0 };

            this.result = list.IncrementLast();
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 1 });
        }
    }
    public class WhenIncrementingLastOfLongList
    {
        private IEnumerable<int> result;

        [SetUp]
        public void EstablishContext()
        {
            var list = new[] { 0, 1 };

            this.result = list.IncrementLast();
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 0, 2 });
        }
    }
    public class WhenIncrementingLastOfLongerList
    {
        private IEnumerable<int> result;

        [SetUp]
        public void EstablishContext()
        {
            var list = new[] { 0, 1, 2 };

            this.result = list.IncrementLast();
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 0, 1, 3 });
        }
    }
}
