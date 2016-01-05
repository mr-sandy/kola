namespace Integration.Tests.Nancy.Modules.TemplatesModuleTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using global::Nancy;
    using global::Nancy.Testing;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenPostingAnAmendment : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var template = new Template(new[] { "test", "path" });
            this.ContentRepository.Stub(r => r.GetTemplate(Arg<IEnumerable<string>>.List.Equal(new[] { "test", "path" }))).Return(template);

            var componentSpecification = new AtomSpecification("atom name");
            this.ComponentLibrary.Stub(r => r.Lookup("atom name")).Return(componentSpecification);

            this.Response = this.Browser.Post("/_kola/template/amendments/addComponent",
                with =>
                    {
                        with.Query("templatePath", "/test/path");
                        with.JsonBody(new
                        {
                            targetPath = "0",
                            componentType = "atom name"
                        });
                        with.Header("Accept", "application/json");
                    });
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldReturnALocationHeader()
        {
            this.Response.Headers["location"].Should().Be("/_kola/template/amendments?templatePath=/test/path&amendmentIndex=0");
        }

        [Test]
        public void ShouldUpdateTemplateToRepository()
        {
            this.ContentRepository.AssertWasCalled(r => r.Update(Arg<Template>.Is.Anything));
        }

        [Test]
        public void ShouldAddAnAmendmentToTheTemplate()
        {
            var args = this.ContentRepository.GetArgumentsForCallsMadeOn(r => r.Update(Arg<Template>.Is.Anything));
            var updatedTemplate = (Template)args[0][0];
            updatedTemplate.Amendments.Should().HaveCount(1);
        }
    }
}