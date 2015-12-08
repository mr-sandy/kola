namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.ResetProperty
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenApplyingAResetPropertyAmendmentWhenThereIsADefaultValue : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Template.Insert(0, new Atom("the atom", new[] { new Property("property name", "property type", new FixedPropertyValue("fixed value")) }));

            var propertiespecification = new PropertySpecification("property name", "property type", "default value");

            this.ComponentSpecification.Stub(s => s.Properties).Return(new[] { propertiespecification });

            var amendment = new ResetPropertyAmendment(new[] { 0 }, "property name");

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void ThePropertyShouldRemain()
        {
            this.Template.Components.First().As<Atom>().Properties.Should().HaveCount(1);
        }

        [Test]
        public void ThePropertyShouldHaveTheDefaultValue()
        {
            this.Template.Components.First().As<Atom>().Properties.Single().Value.As<FixedPropertyValue>().Value.Should().Be("default value");
        }
    }
}