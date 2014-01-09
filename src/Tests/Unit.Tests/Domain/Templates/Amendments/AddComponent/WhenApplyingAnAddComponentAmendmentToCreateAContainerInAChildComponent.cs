namespace Unit.Tests.Domain.Templates.Amendments.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Kola.Domain;

    public class WhenApplyingAnAddComponentAmendmentToCreateAContainerInAChildComponent
    {
        private Container container;

        [SetUp]
        public void EstablishContext()
        {
            this.container = new Container("container 1");
            var amendment = new AddComponentAmendment("container 1", new[] { 0 }, 0);
            var template = new Template(new[] { "path" }, new[] { this.container }, new[] { amendment });

            var newComponent = new Container("container 1");

            var componentLibrary = MockRepository.GenerateStub<IComponentLibrary>();
            var componentSpecification = MockRepository.GenerateStub<IComponentSpecification>();
            componentLibrary.Stub(l => l.Lookup("container 1")).Return(componentSpecification);
            componentSpecification.Stub(s => s.Create()).Return(newComponent);

            template.ApplyAmendments(componentLibrary);
        }

        [Test]
        public void TheContainerShouldContainOneChild()
        {
            this.container.Components.Should().HaveCount(1);
        }

        [Test]
        public void TheComponentShouldBeAnAtom()
        {
            this.container.Components.Single().Should().BeOfType<Container>();
        }
    }
}