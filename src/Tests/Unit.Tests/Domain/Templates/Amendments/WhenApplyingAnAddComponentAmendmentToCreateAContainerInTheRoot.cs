namespace Unit.Tests.Domain.Templates.Amendments
{
    using System.Linq;

    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Unit.Tests.Domain.Fake;
    using Unit.Tests.Domain.Fake.Amendments;

    public class WhenApplyingAnAddComponentAmendmentToCreateAContainerInTheRoot
    {
        private Template template;

        [SetUp]
        public void EstablishContext()
        {
            var amendment = new AddComponentAmendment("container name", Enumerable.Empty<int>(), 0);
            this.template = new Template(amendments: new[] { amendment });

            var newComponent = new Container();

            var componentFactory = MockRepository.GenerateStub<IComponentFactory>();
            componentFactory.Stub(f => f.Create("container name")).Return(newComponent);

            this.template.ApplyAmendments(componentFactory);
        }

        [Test]
        public void TheTemplateShouldContainOneComponent()
        {
            this.template.Components.Should().HaveCount(1);
        }

        [Test]
        public void TheComponentShouldBeAContainer()
        {
            this.template.Components.Single().Should().BeOfType<Container>();
        }
    }
}