namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenProcessingAnAddComponentAmendmentToCreateAnAtomInTheRoot : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            ComponentSpecification.Stub(s => s.Create()).Return(new Atom("new atom", null));

            var amendment = new AddComponentAmendment("new atom", new[] { 0 });

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void TheTemplateShouldContainOneComponent()
        {
            this.Template.Components.Should().HaveCount(1);
        }

        [Test]
        public void TheComponentShouldBeAnAtom()
        {
            this.Template.Components.Single().Should().BeOfType<Atom>();
        }
    }
}