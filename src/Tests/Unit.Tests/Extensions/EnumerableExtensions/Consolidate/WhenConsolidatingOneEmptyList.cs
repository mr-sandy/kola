﻿namespace Unit.Tests.Extensions.EnumerableExtensions.Consolidate
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Extensions;

    using NUnit.Framework;

    public class WhenConsolidatingOneEmptyList
    {
        private IEnumerable<IEnumerable<int>> result;

        [SetUp]
        public void EstablishContext()
        {
            var list1 = Enumerable.Empty<int>();
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
            this.result.ElementAt(0).Should().BeEquivalentTo(Enumerable.Empty<int>());
        }
    }
}