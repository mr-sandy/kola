namespace Unit.Tests.Temp.Tests.WidgetTests
{
    using FluentAssertions;

    using NUnit.Framework;

    using Unit.Tests.Temp.Domain;
    using Unit.Tests.Temp.Domain.Specifications;
    using Unit.Tests.Temp.Domain.Templates;

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
                            new ContainerTemplate(new IComponentTemplate[] { new PlaceholderTemplate() }) 
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