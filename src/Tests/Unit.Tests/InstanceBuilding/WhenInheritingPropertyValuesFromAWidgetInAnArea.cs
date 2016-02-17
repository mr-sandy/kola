namespace Unit.Tests.InstanceBuilding
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    public class WhenInheritingPropertyValuesFromAWidgetInAnArea
    {
        private ComponentInstance instance;

        [SetUp]
        public void SetUp()
        {
            var container = new Container(
                "container",
                new[] { new Property("property-name", "property-type", new InheritedPropertyValue("property-alias")) });

            var placeholder = new Placeholder("area 1");

            var widgetSpecification = new WidgetSpecification(
                "widget",
                new[] { new PropertySpecification("property-alias", "property-type", string.Empty) },
                new[] { placeholder });

            var buildContext = new BuildData(Enumerable.Empty<IContextItem>());

            var widget = widgetSpecification.Create();
            widget.FindOrCreateProperty(new PropertySpecification("property-alias", "property-type", string.Empty));
            widget.Properties.Single().Value = new FixedPropertyValue("property-value");
            widget.Areas.Single().Insert(0, container);

            var builder = new Builder(RenderingInstructions.BuildForPreview(), w => widgetSpecification, null);

            this.instance = widget.Build(builder, new[] { 0 }, buildContext);
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
        public void ShouldContainAPlaceholderInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            widgetInstance.Components.Single().Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void ShouldContainAContainerWithinThePlaceholdersArea()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            var placeholderInstance = (PlaceholderInstance)widgetInstance.Components.Single();
            var areaInstance = (AreaInstance)placeholderInstance.Content;
            areaInstance.Components.Single().Should().BeOfType<ContainerInstance>();
        }

        [Test]
        public void ShouldHaveOnePropertyInContainerInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            var placeholderInstance = (PlaceholderInstance)widgetInstance.Components.Single();
            var areaInstance = (AreaInstance)placeholderInstance.Content;
            var containerInstance = (ContainerInstance)areaInstance.Components.Single();
            containerInstance.Properties.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveInheritedPropertyValueInContainerInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            var placeholderInstance = (PlaceholderInstance)widgetInstance.Components.Single();
            var areaInstance = (AreaInstance)placeholderInstance.Content;
            var containerInstance = (ContainerInstance)areaInstance.Components.Single();
            containerInstance.Properties.Single().Value.Should().Be("property-value");
        }
    }
}