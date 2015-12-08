namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.ClearProperty
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Composition.PropertyValues;

    using NUnit.Framework;

    public class WhenApplyingAClearPropertyAmendment: ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Template.Insert(0, new Atom("the atom", new [] { new Property("property name", "property type", new FixedPropertyValue("fixed value")) }));

            var amendment = new ClearPropertyAmendment(new[] { 0 }, "property name");

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void ThePropertyShouldBeCleared()
        {
            this.Template.Components.First().As<Atom>().Properties.Should().HaveCount(0);
        }
    }
}