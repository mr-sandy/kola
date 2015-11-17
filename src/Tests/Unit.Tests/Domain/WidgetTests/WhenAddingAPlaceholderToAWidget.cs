namespace Unit.Tests.Domain.WidgetTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    public class WhenAddingAPlaceholderToAWidget
    {
        private WidgetSpecification widgetSpecification;

        [SetUp]
        public void SetUp()
        {
            this.widgetSpecification = new WidgetSpecification("widgetName");
            var placeholder = new Placeholder("area 1");

            this.widgetSpecification.Insert(0, placeholder);
        }

        [Test]
        public void TheWidgetSpecificationShouldHaveOneComponent()
        {
            this.widgetSpecification.Components.Should().HaveCount(1);
        }

        [Test]
        public void TheComponentShouldBeAPlaceholder()
        {
            this.widgetSpecification.Components.Single().Should().BeOfType<Placeholder>();
        }
    }
}