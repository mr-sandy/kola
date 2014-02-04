namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenProcessingAnAddComponentAmendmentToCreateASecondAtomInAChildComponent : ContextBase
    {
        private ContainerTemplate container;

        [SetUp]
        public void EstablishContext()
        {
            this.container = new ContainerTemplate("existing container", null);
            this.Template.AddComponent(this.container, 0);

            var existingComponent = new ContainerTemplate("existing sub-container", null);
            this.container.AddComponent(existingComponent, 0);

            this.ComponentSpecification.Stub(s => s.Create()).Return(new AtomTemplate("new atom", null));

            var amendment = new AddComponentAmendment("atom name", new[] { 0, 1 });

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
            this.container.Components.ElementAt(1).Should().BeOfType<AtomTemplate>();
        }
    }
}