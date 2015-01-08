namespace Unit.Tests.Domain.PropertyTests
{
    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances;

    using NUnit.Framework;

    public class WhenCreatingAnInstanceOfAPropertyWithAFixedPropertyValue
    {
        private PropertyInstance propertyInstance;

        [SetUp]
        public void EstablishContext()
        {
            var property = new Property("property name", "property type", new FixedPropertyValue("property value"));

            this.propertyInstance = property.Build(null);
        }

        [Test]
        public void ThePropertyInstanceShouldNotBeNull()
        {
            this.propertyInstance.Should().NotBeNull();
        }

        [Test]
        public void ThePropertyInstanceShouldHaveTheCorrectName()
        {
            this.propertyInstance.Name.Should().Be("property name");
        }

        [Test]
        public void ThePropertyInstanceShouldHaveTheCorrectValue()
        {
            this.propertyInstance.Value.Should().Be("property value");
        }
    }
}