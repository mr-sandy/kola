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

    public class WhenInheritingPropertyValuesFromAContainer
    {
        private ComponentInstance instance;

        [SetUp]
        public void SetUp()
        {
            var atom = new Atom(
                "atom",
                new[] { new Property("property-name", "property-type", new InheritedPropertyValue("property-name")) });

            var containerSpecification = new ContainerSpecification("container");
            containerSpecification.AddProperty(new PropertySpecification("property-name", "property-type", string.Empty));

            var buildContext = new BuildContext();

            var container = containerSpecification.Create();
            container.FindOrCreateProperty(new PropertySpecification("property-name", "property-type", string.Empty));
            container.Properties.Single().Value = new FixedPropertyValue("property-value");
            container.Insert(0, atom);

            var builder = new Builder(new RenderingInstructions(false, true), null);
            this.instance = container.Build(builder, new[] { 0 }, buildContext);
        }

        [Test]
        public void ShouldReturnAContainerInstance()
        {
            this.instance.Should().BeOfType<ContainerInstance>();
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            var containerInstance = (ContainerInstance)this.instance;
            containerInstance.Components.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveAnAtomInstance()
        {
            var containerInstance = (ContainerInstance)this.instance;
            containerInstance.Components.Single().Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void ShouldHaveOnePropertyInAtomInstance()
        {
            var containerInstance = (ContainerInstance)this.instance;
            var atomInstance = (AtomInstance)containerInstance.Components.Single();
            atomInstance.Properties.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveInheritedPropertyValueInAtomInstance()
        {
            var containerInstance = (ContainerInstance)this.instance;
            var atomInstance = (AtomInstance)containerInstance.Components.Single();
            atomInstance.Properties.Single().Value.Should().Be("property-value");
        }
    }
}