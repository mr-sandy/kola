namespace Unit.Tests.InstanceBuilding
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    public class WhenInheritingPropertyValuesFromAWidget2
    {
        private ComponentInstance instance;

        [SetUp]
        public void EstablishContext()
        {
            var container = new Container(
                "container",
                new[] { new Property("property-name", "property-type", new InheritedPropertyValue("property-alias")) });

            var widgetSpecification = new WidgetSpecification(
                "widget",
                new[] { new PropertySpecification("property-alias", "property-type") },
                new[] { container });

            var buildContext = new BuildContext
                {
                    WidgetSpecificationFinder = w => widgetSpecification
                };

            var widget = widgetSpecification.Create();
            widget.AddProperty(new PropertySpecification("property-alias", "property-type"));
            widget.Properties.Single().Value = new FixedPropertyValue("property-value");

            this.instance = widget.Build(new[] { 0 }, buildContext);
        }

        [Test]
        public void ShouldReturnAWidgetInstance()
        {
            this.instance.Should().BeOfType<WidgetInstance>();
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            widgetInstance.Components.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveAnContainerInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            widgetInstance.Components.Single().Should().BeOfType<ContainerInstance>();
        }

        [Test]
        public void ShouldHaveOnePropertyInContainerInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            var containerInstance = (ContainerInstance)widgetInstance.Components.Single();
            containerInstance.Properties.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveInheritedPropertyValueInContainerInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            var containerInstance = (ContainerInstance)widgetInstance.Components.Single();
            containerInstance.Properties.Single().Value.Should().Be("property-value");
        }
    }
}