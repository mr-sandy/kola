namespace Unit.Tests.Domain.Templates.Amendments.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Kola.Domain;

    public class WhenApplyingAnAddComponentAmendmentToCreateAContainerInTheRoot
    {
        private Template template;

        [SetUp]
        public void EstablishContext()
        {
            var amendment = new AddComponentAmendment("container 1", Enumerable.Empty<int>(), 0);
            this.template = new Template(new[] { "path" }, amendments: new[] { amendment });

            var newComponent = new Container("container 1");

            var componentLibrary = MockRepository.GenerateStub<IComponentLibrary>();
            var componentSpecification = MockRepository.GenerateStub<IComponentSpecification>();
            componentLibrary.Stub(l => l.Lookup("container 1")).Return(componentSpecification);
            componentSpecification.Stub(s => s.Create()).Return(newComponent);

            this.template.ApplyAmendments(componentLibrary);
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