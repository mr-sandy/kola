namespace Unit.Tests.Domain.Templates.Amendments
{
    using System.Linq;

    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Unit.Tests.Domain.Fake;
    using Unit.Tests.Domain.Fake.Amendments;

    public class WhenApplyingAnAddComponentAmendmentToCreateASecondAtomInAChildComponent
    {
        private Container container;

        [SetUp]
        public void EstablishContext()
        {
            this.container = new Container();

            var amendment = new AddComponentAmendment("atom name", new[] { 0 }, 1);
            var template = new Template(new[] { this.container }, new[] { amendment });

            var existingComponent = new Container();
            this.container.AddComponent(existingComponent, 0);

            var newComponent = new Atom();

            var componentFactory = MockRepository.GenerateStub<IComponentFactory>();
            componentFactory.Stub(f => f.Create("atom name")).Return(newComponent);

            template.ApplyAmendments(componentFactory);
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