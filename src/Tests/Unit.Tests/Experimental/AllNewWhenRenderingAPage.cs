namespace Unit.Tests.Experimental
{
    using System;
    using System.Collections.Generic;

    using FluentAssertions;

    using NUnit.Framework;

    using Unit.Tests.Experimental.Framework;

    public class AllNewWhenRenderingAPage
    {
        private string result;

        [SetUp]
        public void EstablishContext()
        {
            var mappings = new Dictionary<string, Func<IViewHelper, View>>
            { 
                { "page", h => new PageView(h) }, 
                { "atom1", h => new AtomView(h, "<atom1/>") } 
            };

            var viewHelper = new TestViewHelper();
            var viewFactory = new TestViewFactory(viewHelper, mappings);

            var page = new TestPage { Components = new[] { new TestComponent { Name = "atom1" } } };

            this.result = viewFactory["page"].Render(page);
        }

        [Test]
        public void ShouldReturnAResult()
        {
            this.result.Should().NotBeNull();
        }

        [Test]
        public void ResultShouldIncludeHtmlForAtom1()
        {
            this.result.Should().Contain("<atom1/>");
        }
    }
}