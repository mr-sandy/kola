namespace Unit.Tests.Domain.WidgetTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    using NUnit.Framework;

    public class WhenCreatingAWidgetFromItsSpecification
    {
        private WidgetTemplate widget;

        [SetUp]
        public void EstablishContext()
        {
            var container1 = new ContainerTemplate("container 1", Enumerable.Empty<ParameterTemplate>(), new[] { new PlaceholderTemplate() });
            var container2 = new ContainerTemplate("container 2", Enumerable.Empty<ParameterTemplate>(), new[] { new PlaceholderTemplate() });
            var specification = new WidgetSpecification("widget name", new[] { container1, container2 });

//            this.widget = specification.Create();
        }

        [Test]
        public void TheWidgetShouldHaveTwoAreas()
        {
//            this.widget.Areas.Should().HaveCount(2);
        }
    }
}