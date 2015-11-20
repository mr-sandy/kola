namespace Unit.Tests.Extensions.ContextItemExtensions
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Context;

    using NUnit.Framework;

    public class WhenMergingTwoDisinctContexts
    {
        private IEnumerable<IContextItem> context1 = new[]
                                                         {
                                                             new ContextItem("item 1", "value 1"),
                                                             new ContextItem("item 2", "value 2"),
                                                             new ContextItem("item 3", "value 3")
                                                         };

        private IEnumerable<IContextItem> context2 = new[]
                                                 {
                                                             new ContextItem("item 4", "value 4"),
                                                             new ContextItem("item 5", "value 5"),
                                                             new ContextItem("item 6", "value 6")
                                                         };
        private IEnumerable<IContextItem> result;

        [SetUp]
        public void SetUp()
        {
            this.result = this.context1.Merge(this.context2);
        }

        [Test]
        public void TheResultShouldContainAllItemsFromEach()
        {
            this.result.Should().HaveCount(6);
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
