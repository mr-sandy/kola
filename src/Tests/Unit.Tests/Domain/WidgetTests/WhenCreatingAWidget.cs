namespace Unit.Tests.Domain.WidgetTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    public class WhenCreatingAWidget
    {
        private Widget widget;

        [SetUp]
        public void SetUp()
        {
            var specification =
                new WidgetSpecification(
                    "widget name",
                    Enumerable.Empty<PropertySpecification>(),
                    new IComponent[]
                        {
                            new Placeholder("area 1"), 
                            new Container(
                                "container name", 
                                Enumerable.Empty<Property>(),
                                new IComponent[] { new Placeholder("area 2") }) 
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