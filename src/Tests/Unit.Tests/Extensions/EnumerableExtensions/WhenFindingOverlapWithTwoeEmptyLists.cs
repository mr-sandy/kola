namespace Unit.Tests.Extensions.EnumerableExtensions
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Extensions;

    using NUnit.Framework;

    public class WhenFindingOverlapWithTwoeEmptyLists
    {
        private IEnumerable<int> result;

        [SetUp]
        public void EstablishContext()
        {
            var list1 = Enumerable.Empty<int>();
            var list2 = Enumerable.Empty<int>();

            this.result = list1.GetOverlap(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEmpty();
        }
    }
}