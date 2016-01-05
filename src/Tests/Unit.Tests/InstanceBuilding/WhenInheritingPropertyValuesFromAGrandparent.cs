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

    public class WhenInheritingPropertyValuesFromAContainerGrandparent
    {
        private ComponentInstance instance;

        [SetUp]
        public void SetUp()
        {
            var atom = new Atom(
                "atom",
                new[] { new Property("property-name", "property-type", new InheritedPropertyValue("property-name")) });

            var parentSpecification = new ContainerSpecification("parent-container");

            var grandparentSpecification = new ContainerSpecification("grandparent-container");
            grandparentSpecification.AddProperty(new PropertySpecification("property-name", "property-type", string.Empty));

            var buildContext = new BuildSettings(Enumerable.Empty<IContextItem>());

            var parent = parentSpecification.Create();
            parent.Insert(0, atom);

            var grandparent = grandparentSpecification.Create();
            grandparent.FindOrCreateProperty(new PropertySpecification("property-name", "property-type", string.Empty));
            grandparent.Properties.Single().Value = new FixedPropertyValue("property-value");
            grandparent.Insert(0, parent);

            var builder = new Builder(new RenderingInstructions(false, true), null);
            this.instance = grandparent.Build(builder, new[] { 0 }, buildContext);
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
        public void ShouldHaveAChildContainerInstance()
        {
            var grandparentInstance = (ContainerInstance)this.instance;
            grandparentInstance.Components.Single().Should().BeOfType<ContainerInstance>();
        }

        [Test]
        public void ShouldHaveAGrandchildAtomInstance()
        {
            var grandparentInstance = (ContainerInstance)this.instance;
            var parentInstance = (ContainerInstance)grandparentInstance.Components.Single();
            parentInstance.Components.Single().Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void ShouldHaveOnePropertyInAtomInstance()
        {
            var grandparentInstance = (ContainerInstance)this.instance;
            var parentInstance = (ContainerInstance)grandparentInstance.Components.Single();
            var atomInstance = (AtomInstance)parentInstance.Components.Single();
            atomInstance.Properties.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveInheritedPropertyValueInAtomInstance()
        {
            var grandparentInstance = (ContainerInstance)this.instance;
            var parentInstance = (ContainerInstance)grandparentInstance.Components.Single();
            var atomInstance = (AtomInstance)parentInstance.Components.Single();
            atomInstance.Properties.Single().Value.Should().Be("property-value");
        }
    }
}