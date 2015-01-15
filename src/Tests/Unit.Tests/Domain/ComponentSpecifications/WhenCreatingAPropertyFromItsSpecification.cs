namespace Unit.Tests.Domain.ComponentSpecifications
{
    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    [TestFixture]
    public class WhenCreatingAPropertyFromItsSpecification
    {
        private Property property;

        [SetUp]
        public void SetUp()
        {
            var propertySpecification = new PropertySpecification("property 1 name", "property 1 type");

            this.property = propertySpecification.Create();
        }

        [Test]
        public void ThePropertyShouldHaveTheCorrectName()
        {
            this.property.Name.Should().Be("property 1 name");
        }

        [Test]
        public void ThePropertyShouldHaveTheCorrectType()
        {
            this.property.Type.Should().Be("property 1 type");
        }
    }
}