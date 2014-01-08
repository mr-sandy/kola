namespace Unit.Tests.Domain.Templates.Amendments
{
    using System.Linq;

    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Unit.Tests.Domain.Fake;
    using Unit.Tests.Domain.Fake.Amendments;

    public class WhenApplyingAnAddComponentAmendmentToCreateAnAtomInAChildComponent
    {
        private Container container;

        [SetUp]
        public void EstablishContext()
        {
            this.container = new Container();
            var amendment = new AddComponentAmendment("atom name", new[] { 0 }, 0);
            var template = new Template(new[] { this.container }, new[] { amendment });

            var newComponent = new Atom();

            var componentFactory = MockRepository.GenerateStub<IComponentFactory>();
            componentFactory.Stub(f => f.Create("atom name")).Return(newComponent);

            template.ApplyAmendments(componentFactory);
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