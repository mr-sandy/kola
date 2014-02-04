namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenProcessingAnAddComponentAmendmentToCreateAnAtomInAChildComponent : ContextBase
    {
        private ContainerTemplate container;

        [SetUp]
        public void EstablishContext()
        {
            this.container = new ContainerTemplate("existing container", null);
            this.Template.AddComponent(this.container, 0);

            var newComponent = new AtomTemplate("new atom", null);

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
            this.container.Components.Single().Should().BeOfType<AtomTemplate>();
        }
    }
}