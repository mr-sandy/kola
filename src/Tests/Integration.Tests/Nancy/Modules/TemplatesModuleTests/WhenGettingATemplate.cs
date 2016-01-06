namespace Integration.Tests.Nancy.Modules.TemplatesModuleTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using global::Nancy;
    using global::Nancy.Testing;

    using Kola.Domain.Composition;
    using Kola.Resources;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingATemplate : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var template = new Template(new[] { "test", "path" });

            this.ContentRepository.Stub(r => r.GetTemplate(Arg<IEnumerable<string>>.List.Equal(new[] { "test", "path" }))).Return(template);

            this.Response = this.Browser.Get(
                "/_kola/templates",
                with =>
                    {
                        with.Query("templatePath", "/test/path");
                        with.Header("Accept", "application/json");
                    });
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnATemplateResource()
        {
            this.Response.Body.DeserializeJson<TemplateResource>().Should().NotBeNull();
        }

        [Test]
        public void ShouldContainASelfLink()
        {
            this.Response.Body.DeserializeJson<TemplateResource>().Links.Should().Contain(l => l.Rel == "self" && l.Href == "/_kola/templates?templatePath=/test/path");
        }

        [Test]
        public void ShouldContainAPreviewLink()
        {
            this.Response.Body.DeserializeJson<TemplateResource>().Links.Should().Contain(l => l.Rel == "preview" && l.Href == "/test/path?preview=y");
        }
    }
}