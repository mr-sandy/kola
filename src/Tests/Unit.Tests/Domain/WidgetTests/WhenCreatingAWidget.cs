namespace Unit.Tests.Domain.WidgetTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Specifications;
    using Kola.Domain.Composition;

    using NUnit.Framework;

    public class WhenCreatingAWidget
    {
        private Widget widget;

        [SetUp]
        public void EstablishContext()
        {
            var specification =
                new WidgetSpecification(
                    "widget name",
                    new IComponent[]
                        {
                            new Placeholder(), 
                            new Container(
                                "container name", 
                                Enumerable.Empty<Property>(),
                                new IComponent[] { new Placeholder() }) 
                        });

            this.widget = specification.Create();
        }

        [Test]
        public void ShouldHaveTwoAreas()
        {
            this.widget.Areas.Should().HaveCount(2);
        }
    }
}