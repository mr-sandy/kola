namespace Unit.Tests.Domain.PropertyTests
{
    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    using NUnit.Framework;

    public class WhenCreatingAnInstanceOfAPropertyWithAnInheritedPropertyValue
    {
        private PropertyInstance propertyInstance;

        [SetUp]
        public void EstablishContext()
        {
            var property = new Property("property name", "property type", new InheritedPropertyValue("key"));

            var context = new Context { Items = new[] { new ContextItem("key", "result") } };

            this.propertyInstance = property.Build(new BuildContext { Contexts = new[] { context } });
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
            this.propertyInstance.Value.Should().Be("result");
        }
    }
}