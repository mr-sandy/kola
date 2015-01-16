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

    public class WhenInheritingPropertyValuesFromAWidgetwidget
    {
        private ComponentInstance instance;

        [SetUp]
        public void EstablishContext()
        {
            var atom = new Atom(
                "atom",
                new[] { new Property("property-name", "property-type", new InheritedPropertyValue("property-alias")) });

            var containerSpecification = new ContainerSpecification("container");
            var container = containerSpecification.Create();
            container.Insert(0, atom);

            var widgetSpecification = new WidgetSpecification(
                "widget",
                new[] { new PropertySpecification("property-alias", "property-type", string.Empty) }, 
                new[] { container });

            var buildContext = new BuildContext
            {
                WidgetSpecificationFinder = w => widgetSpecification
            };

            var widget = widgetSpecification.Create();
            widget.AddProperty(new PropertySpecification("property-alias", "property-type", string.Empty));
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
        public void ShouldHaveAChildContainerInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            widgetInstance.Components.Single().Should().BeOfType<ContainerInstance>();
        }

        [Test]
        public void ShouldHaveAGrandchildAtomInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            var containerInstance = (ContainerInstance)widgetInstance.Components.Single();
            containerInstance.Components.Single().Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void ShouldHaveOnePropertyInAtomInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            var containerInstance = (ContainerInstance)widgetInstance.Components.Single();
            var atomInstance = (AtomInstance)containerInstance.Components.Single();
            atomInstance.Properties.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveInheritedPropertyValueInAtomInstance()
        {
            var widgetInstance = (WidgetInstance)this.instance;
            var containerInstance = (ContainerInstance)widgetInstance.Components.Single();
            var atomInstance = (AtomInstance)containerInstance.Components.Single();
            atomInstance.Properties.Single().Value.Should().Be("property-value");
        }
    }
}