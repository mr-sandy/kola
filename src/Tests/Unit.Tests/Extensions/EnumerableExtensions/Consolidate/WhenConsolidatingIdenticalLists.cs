namespace Unit.Tests.Extensions.EnumerableExtensions.Consolidate
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Extensions;

    using NUnit.Framework;

    public class WhenConsolidatingIdenticalLists
    {
        private IEnumerable<IEnumerable<int>> result;

        [SetUp]
        public void EstablishContext()
        {
            var list1 = new[] { 1, 2, 3 };
            var list2 = new[] { 1, 2, 3 };

            this.result = list1.Consolidate(list2);
        }

        [Test]
        public void ShouldReturnCorrectNumberOfLists()
        {
            this.result.Should().HaveCount(1);
        }

        [Test]
        public void ShouldReturnCorrectElements()
        {
            this.result.ElementAt(0).Should().BeEquivalentTo(new[] { 1, 2, 3 });
        }
    }
}