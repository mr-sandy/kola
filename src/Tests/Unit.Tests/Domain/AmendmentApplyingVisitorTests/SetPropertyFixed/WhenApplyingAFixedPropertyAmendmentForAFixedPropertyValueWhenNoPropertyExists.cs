namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.SetPropertyFixed
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenApplyingAFixedPropertyAmendmentForAFixedPropertyValueWhenNoPropertyExists : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Template.Insert(0, new Atom("the atom", Enumerable.Empty<Property>()));

            var propertiespecification = new PropertySpecification("property name", "property type", string.Empty);

            this.ComponentSpecification.Stub(s => s.Properties).Return(new[] { propertiespecification });

            var amendment = new SetPropertyFixedAmendment(new[] { 0 }, "property name", "updated value");

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void ThePropertyShouldBeOfTheCorrectType()
        {
            this.Template.Components.First().As<Atom>().Properties.Single().Value.Should().BeOfType<FixedPropertyValue>();
        }

        [Test]
        public void ThePropertyShouldHaveTheCorrectValue()
        {
            var value = (FixedPropertyValue)this.Template.Components.First().As<Atom>().Properties.Single().Value;

            value.Value.Should().Be("updated value");
        }
    }
}