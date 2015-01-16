namespace Unit.Tests.Domain.ComponentSpecifications
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    [TestFixture]
    public class WhenCreatingAnAtomFromItsSpecification
    {
        private Atom atom;

        [SetUp]
        public void SetUp()
        {
            var atomSpecification = new AtomSpecification("atom 1");
            atomSpecification.AddProperty(new PropertySpecification("property 1 name", "property 1 type", string.Empty));
            atomSpecification.AddProperty(new PropertySpecification("property 2 name", "property 2 type", "property 2 default"));

            this.atom = atomSpecification.Create();
        }

        [Test]
        public void TheAtomShouldHaveTheCorrectName()
        {
            this.atom.Name.Should().Be("atom 1");
        }

        [Test]
        public void TheAtomShouldContainerPropertiesWhereDetaultIsSpecified()
        {
            this.atom.Properties.Should().HaveCount(1);
        }

        [Test]
        public void TheAtomShouldHaveTheCorrectPropertyValueTypeForDefaultProperties()
        {
            var property = this.atom.Properties.Single();
            property.Value.Should().BeOfType<FixedPropertyValue>();
        }

        [Test]
        public void TheAtomShouldHaveTheCorrectValueForDefaultProperties()
        {
            var property = this.atom.Properties.Single();
            var value = (FixedPropertyValue)property.Value;

            value.Value.Should().Be("property 2 default");
        }
    }
}