namespace Unit.Tests.Domain.WidgetTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    using NUnit.Framework;

    public class WhenCreatingAWidget
    {
        private WidgetTemplate widget;

        [SetUp]
        public void EstablishContext()
        {
            var specification =
                new WidgetSpecification(
                    "widget name",
                    new IComponentTemplate[]
                        {
                            new PlaceholderTemplate(), 
                            new ContainerTemplate(
                                "container name", 
                                Enumerable.Empty<ParameterTemplate>(),
                                new IComponentTemplate[] { new PlaceholderTemplate() }) 
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