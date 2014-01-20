namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Amendments;
    using Kola.Domain.Templates;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenProcessingAnAddComponentAmendmentToCreateAnAtomInAChildComponent : ContextBase
    {
        private Container container;

        [SetUp]
        public void EstablishContext()
        {
            this.container = new Container("existing container");
            this.Template.AddComponent(this.container, 0);

            var newComponent = new Atom("new atom");

            this.ComponentSpecification.Stub(s => s.Create()).Return(newComponent);

            var amendment = new AddComponentAmendment("new atom", new[] { 0, 0 });

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void TheContainerShouldContainOneChild()
        {
            this.container.Components.Should().HaveCount(1);
        }

        [Test]
        public void TheComponentShouldBeAnAtom()
        {
            this.container.Components.Single().Should().BeOfType<Atom>();
        }
    }
}