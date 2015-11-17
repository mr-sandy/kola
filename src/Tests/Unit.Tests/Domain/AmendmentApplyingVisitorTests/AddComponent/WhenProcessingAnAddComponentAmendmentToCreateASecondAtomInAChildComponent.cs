namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenProcessingAnAddComponentAmendmentToCreateASecondAtomInAChildComponent : ContextBase
    {
        private Container container;

        [SetUp]
        public void SetUp()
        {
            this.container = new Container("existing container", null);
            this.Template.Insert(0, this.container);

            var existingComponent = new Container("existing sub-container", null);
            this.container.Insert(0, existingComponent);

            this.ComponentSpecification.Stub(s => s.Create()).Return(new Atom("new atom", null));

            var amendment = new AddComponentAmendment(new[] { 0, 1 }, "atom name");

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void TheContainerShouldContainTwoChildren()
        {
            this.container.Components.Should().HaveCount(2);
        }

        [Test]
        public void TheComponentShouldBeAnAtom()
        {
            this.container.Components.ElementAt(1).Should().BeOfType<Atom>();
        }
    }
}