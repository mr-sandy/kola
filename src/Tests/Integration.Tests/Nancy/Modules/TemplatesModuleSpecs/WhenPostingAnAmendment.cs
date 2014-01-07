namespace Integration.Tests.Nancy.Modules.TemplatesModuleSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Kola.Editing;
    using Kola.Resources;

    using global::Nancy;
    using global::Nancy.Testing;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenPostingAnAmendment : ContextBase
    {
        private Template template;

        [SetUp]
        public void EstablishContext()
        {
            var templatePath = @"test/path";

            this.template = new Template(new[] { "test", "path" });
            this.TemplateRepository.Stub(r => r.Get(Arg<IEnumerable<string>>.Is.Anything)).Return(this.template);
            this.ComponentFactory.Stub(r => r.Create(Arg<string>.Is.Anything)).Return(new CompositeComponent());

            var request = new AddComponentAmendmentResource
            {
                ComponentPath = string.Empty,
                ComponentType = "component-type",
                Index = 0
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
            this.TemplateRepository.AssertWasCalled(r => r.Update(Arg<Template>.Is.Anything));
        }

        [Test]
        public void ShouldAddAnAmendmentToTheTemplate()
        {
            var args = this.TemplateRepository.GetArgumentsForCallsMadeOn(r => r.Update(Arg<Template>.Is.Anything));
            var updatedTemplate = (Template)args[0][0];
            updatedTemplate.Amendments.Should().HaveCount(1);
        }
    }
}
