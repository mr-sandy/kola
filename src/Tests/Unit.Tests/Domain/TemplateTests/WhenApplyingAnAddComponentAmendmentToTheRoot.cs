namespace Unit.Tests.Domain.TemplateTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Amendments;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenApplyingAnAddComponentAmendmentToTheRoot
    {
        private Template template;

        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.template = new Template(templatePath);

            var amendment = new AddComponentAmendment("component name", new[] { 0 });
            this.template.AddAmendment(amendment);

            var newComponent = new Atom("component name");

            var componentLibrary = MockRepository.GenerateStub<IComponentSpecificationLibrary>();
            var componentSpecification = MockRepository.GenerateStub<IComponentSpecification<Atom>>();
            componentLibrary.Stub(l => l.Lookup("component name")).Return(componentSpecification);
            componentSpecification.Stub(s => s.Create()).Return(newComponent);

            this.template.ApplyAmendments(componentLibrary);
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            this.template.Components.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveCorrectComponentType()
        {
            this.template.Components.ElementAt(0).Name.Should().Be("component name");
        }
    }
}
