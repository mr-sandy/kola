namespace Unit.Tests.Extensions.ContextItemExtensions
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Config;

    using NUnit.Framework;

    public class WhenMergingOverlappingContexts
    {
        private IEnumerable<IContextItem> context1 = new[]
                                                         {
                                                             new ContextItem("item 1", "value 1"),
                                                             new ContextItem("item 2", "value 2"),
                                                             new ContextItem("item 3", "value 3")
                                                         };

        private IEnumerable<IContextItem> context2 = new[]
                                                         {
                                                             new ContextItem("item 2", "value 2"),
                                                             new ContextItem("item 3", "value 3"),
                                                             new ContextItem("item 4", "value 4")
                                                         };
        private IEnumerable<IContextItem> result;

        [SetUp]
        public void SetUp()
        {
            this.result = this.context1.Merge(this.context2);
        }

        [Test]
        public void TheResultShouldAItemForEachDistinctKey()
        {
            this.result.Should().HaveCount(4);
        }

        [Test]
        public void TheFirstSourceContextShoulbeUnchanged()
        {
            this.context1.Should().HaveCount(3);
        }

        [Test]
        public void TheSecondSourceContextShoulbeUnchanged()
        {
            this.context2.Should().HaveCount(3);
        }
    }
}