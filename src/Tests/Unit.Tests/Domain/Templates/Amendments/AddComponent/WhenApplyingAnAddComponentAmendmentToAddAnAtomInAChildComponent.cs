namespace Unit.Tests.Domain.Templates.Amendments.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Kola.Domain;

    public class WhenApplyingAnAddComponentAmendmentToCreateASecondAtomInAChildComponent
    {
        private Container container;

        [SetUp]
        public void EstablishContext()
        {
            this.container = new Container("container 1");

            var amendment = new AddComponentAmendment("atom name", new[] { 0 }, 1);
            var template = new Template(new[] { "path" }, new[] { this.container }, new[] { amendment });

            var existingComponent = new Container("container 0");
            this.container.AddComponent(existingComponent, 0);

            var newComponent = new Atom("atom 1");

            var componentLibrary = MockRepository.GenerateStub<IComponentLibrary>();
            var componentSpecification = MockRepository.GenerateStub<IComponentSpecification>();
            componentLibrary.Stub(l => l.Lookup("atom name")).Return(componentSpecification);
            componentSpecification.Stub(s => s.Create()).Return(newComponent);

            template.ApplyAmendments(componentLibrary);
        }

        [Test]
        public void TheContainerShouldContainOneChild()
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