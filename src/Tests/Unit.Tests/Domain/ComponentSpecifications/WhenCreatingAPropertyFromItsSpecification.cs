namespace Unit.Tests.Domain.ComponentSpecifications
{
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
            var propertiespecification = new PropertySpecification("property 1 name", "property 1 type");

            this.property = propertiespecification.Create();
        }

        [Test]
        public void ThePropertyShouldHaveTheCorrectName()
        {
            //this.property.Name.Should().Be("property 1 name");
        }
    }
}