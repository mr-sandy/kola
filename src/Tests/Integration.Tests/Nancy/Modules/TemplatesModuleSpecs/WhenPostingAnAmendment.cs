namespace Integration.Tests.Nancy.Modules.TemplatesModuleSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;
    using Kola.Resources;

    using global::Nancy;
    using global::Nancy.Testing;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenPostingAnAmendment : ContextBase
    {
        private PageTemplate template;

        [SetUp]
        public void EstablishContext()
        {
            var templatePath = @"test/path";

            this.template = new PageTemplate(new[] { "test", "path" });

            var component = MockRepository.GenerateStub<INamedComponentTemplate>();
            var componentSpecification = MockRepository.GenerateStub<INamedComponentSpecification<INamedComponentTemplate>>();

            componentSpecification.Stub(s => s.Create()).Return(component);
            this.TemplateRepository.Stub(r => r.Get(Arg<IEnumerable<string>>.Is.Anything)).Return(this.template);
            this.ComponentLibrary.Stub(r => r.Lookup("component name")).Return(componentSpecification);

            var request = new AddComponentAmendmentResource
            {
                TargetPath = "0",
                ComponentType = "component name"
            };

            this.Response = this.Browser.Post(string.Format("/_kola/templates/{0}/_amendments/addComponent", templatePath), with => with.JsonBody(request));
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldUpdateTemplateToRepository()
        {
            this.TemplateRepository.AssertWasCalled(r => r.Update(Arg<PageTemplate>.Is.Anything));
        }

        [Test]
        public void ShouldAddAnAmendmentToTheTemplate()
        {
            var args = this.TemplateRepository.GetArgumentsForCallsMadeOn(r => r.Update(Arg<PageTemplate>.Is.Anything));
            var updatedTemplate = (PageTemplate)args[0][0];
            updatedTemplate.Amendments.Should().HaveCount(1);
        }
    }
}
