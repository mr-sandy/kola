namespace Unit.Tests.Domain.TemplateTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenApplyingAnAddComponentAmendmentToTheRoot
    {
        private PageTemplate template;

        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.template = new PageTemplate(templatePath);

            var amendment = new AddComponentAmendment("component name", new[] { 0 });
            this.template.AddAmendment(amendment);

            var newComponent = new AtomTemplate("component name", null);

            var componentLibrary = MockRepository.GenerateStub<IComponentSpecificationLibrary>();
            var componentSpecification = MockRepository.GenerateStub<INamedComponentSpecification<AtomTemplate>>();
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
            this.template.Components.ElementAt(0).As<AtomTemplate>().Name.Should().Be("component name");
        }
    }
}
