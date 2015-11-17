namespace Unit.Tests.InstanceBuilding
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    public class WhenInheritingPropertyValuesFromAWidget
    {
        private ComponentInstance instance;

        [SetUp]
        public void SetUp()
        {
            var atom = new Atom(
                "atom",
                new[] { new Property("property-name", "property-type", new InheritedPropertyValue("property-alias")) });

            var widgetSpecification = new WidgetSpecification(
                "widget",
                new[] { new PropertySpecification("property-alias", "property-type", string.Empty) }, 
                new[] { atom });

            var buildContext = new BuildContext
                {
                    WidgetSpecificationFinder = w => widgetSpecification
                };

            var widget = widgetSpecification.Create();
            widget.FindOrCreateProperty(new PropertySpecification("property-alias", "property-type", string.Empty));
            widget.Properties.Single().Value = new FixedPropertyValue("property-value");

            var builder = new Builder(new RenderingInstructions(false, true));
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
        public void ShouldHaveAnAtomInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            widgetInstance.Components.Single().Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void ShouldHaveOnePropertyInAtomInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            var atomInstance = (AtomInstance)widgetInstance.Components.Single();
            atomInstance.Properties.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveInheritedPropertyValueInAtomInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            var atomInstance = (AtomInstance)widgetInstance.Components.Single();
            atomInstance.Properties.Single().Value.Should().Be("property-value");
        }
    }
}