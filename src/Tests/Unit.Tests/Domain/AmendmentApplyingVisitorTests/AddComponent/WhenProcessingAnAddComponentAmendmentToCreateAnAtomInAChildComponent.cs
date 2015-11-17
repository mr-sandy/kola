namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenProcessingAnAddComponentAmendmentToCreateAnAtomInAChildComponent : ContextBase
    {
        private Container container;

        [SetUp]
        public void SetUp()
        {
            this.container = new Container("existing container", null);
            this.Template.Insert(0, this.container);

            var newComponent = new Atom("new atom", null);

            this.ComponentSpecification.Stub(s => s.Create()).Return(newComponent);

            var amendment = new AddComponentAmendment(new[] { 0, 0 }, "new atom");

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