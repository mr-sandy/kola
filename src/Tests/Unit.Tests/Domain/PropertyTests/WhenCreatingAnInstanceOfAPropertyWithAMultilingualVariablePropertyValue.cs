namespace Unit.Tests.Domain.PropertyTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;

    using NUnit.Framework;

    public class WhenCreatingAnInstanceOfAPropertyWithAMultilingualVariablePropertyValue
    {
        private PropertyInstance propertyInstance;

        [SetUp]
        public void EstablishContext()
        {
            var property = new Property(
                "property name",
                "property type",
                new MultilingualPropertyValue(
                    new[]
                        {
                            new MultilingualVariant("en", "English"), 
                            new MultilingualVariant("fr", "Français")
                        }));

            var context = new ContextSet(Enumerable.Empty<IContextItem>(), "fr");

            var buildContext = new BuildContext();
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
            this.propertyInstance.Value.Should().Be("Français");
        }
    }
}