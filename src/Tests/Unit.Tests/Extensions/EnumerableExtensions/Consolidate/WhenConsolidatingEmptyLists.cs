namespace Unit.Tests.Extensions.EnumerableExtensions.Consolidate
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Extensions;

    using NUnit.Framework;

    public class WhenConsolidatingEmptyLists
    {
        private IEnumerable<IEnumerable<int>> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = Enumerable.Empty<int>();
            var list2 = Enumerable.Empty<int>();

            this.result = list1.Consolidate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().HaveCount(1);
        }
    }
}