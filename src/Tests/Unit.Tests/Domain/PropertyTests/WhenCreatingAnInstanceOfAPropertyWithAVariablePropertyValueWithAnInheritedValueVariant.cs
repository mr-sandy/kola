namespace Unit.Tests.Domain.PropertyTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;

    using NUnit.Framework;

    public class WhenCreatingAnInstanceOfAPropertyWithAVariablePropertyValueWithAnInheritedValueVariant
    {
        private PropertyInstance propertyInstance;

        [SetUp]
        public void SetUp()
        {
            var property = new Property(
                "property name",
                "property type",
                new VariablePropertyValue(
                    "language code",
                    new[]
                        {
                            new PropertyVariant("en", new FixedPropertyValue("English"), true),
                            new PropertyVariant("fr", new InheritedPropertyValue("french message"))
                        }));

            var buildContext = new BuildData(new[] { new ContextItem("french message", "Bonjour!"), new ContextItem("language code", "fr") });

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
        public void ThePropertyInstanceShouldHaveTheDefaultValue()
        {
            this.propertyInstance.Value.Should().Be("Bonjour!");
        }
    }
}