namespace Integration.Tests.Nancy.Modules.TemplatesModuleTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using global::Nancy;
    using global::Nancy.Testing;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Resources;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAmendments : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var template = new Template(new[] { "test", "path" }, null, new[] { new AddComponentAmendment(new[] { 0 }, "atom 1") });

            this.ContentRepository.Stub(r => r.GetTemplate(Arg<IEnumerable<string>>.List.Equal(new[] { "test", "path" }))).Return(template);

            this.Response = this.Browser.Get(
                "/_kola/templates/amendments",
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
        public void ShouldReturnAListOfAmendmentResources()
        {
            this.Response.Body.DeserializeJson<AddComponentAmendmentResource[]>().Should().NotBeNull();
        }
    }
}