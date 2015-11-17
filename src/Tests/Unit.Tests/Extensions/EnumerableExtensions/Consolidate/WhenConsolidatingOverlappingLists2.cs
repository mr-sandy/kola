namespace Unit.Tests.Extensions.EnumerableExtensions.Consolidate
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Extensions;

    using NUnit.Framework;

    public class WhenConsolidatingOverlappingLists2
    {
        private IEnumerable<IEnumerable<int>> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 1, 2, 3, 4, 5 };
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