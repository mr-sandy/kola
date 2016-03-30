namespace Unit.Tests.Domain.PropertyTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenCreatingAnInstanceOfAPropertyWithAnInheritedPropertyValue
    {
        private PropertyInstance propertyInstance;

        [SetUp]
        public void SetUp()
        {
            var property = new Property("property name", "property type", new InheritedPropertyValue("key"));

            var contextItem = MockRepository.GenerateMock<IContextItem>();
            contextItem.Stub(c => c.Name).Return("key");
            contextItem.Stub(c => c.Value).Return("result");

            var context = new[] { contextItem };

            var buildContext = new BuildData(Enumerable.Empty<IContextItem>());
            buildContext.ContextSets.Push(context);

            this.propertyInstance = property.Build(buildContext);
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