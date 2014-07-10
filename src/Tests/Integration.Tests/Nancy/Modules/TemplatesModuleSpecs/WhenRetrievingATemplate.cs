namespace Integration.Tests.Nancy.Modules.TemplatesModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using CsQuery.Utility;

    using FluentAssertions;

    using Kola.Domain.Composition;

    using global::Nancy;
    using global::Nancy.Testing;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenRetrievingATemplate : ContextBase
    {
        private string templatePath = @"test/path";

        private dynamic jsonResponse;

        [SetUp]
        public void EstablishContext()
        {
            var template = new Template(new[] { "test", "path" });

            this.TemplateRepository.Stub(r => r.Get(Arg<IEnumerable<string>>.Is.Anything)).Return(template);


            this.Response = this.Browser.Get(string.Format("/_kola/templates/{0}", this.templatePath), with => with.Header("Accept", "application/json"));
            this.jsonResponse = JSON.ParseJSON(Response.Body.AsString());
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldLookupTemplateToRepository()
        {
            this.TemplateRepository.AssertWasCalled(r => r.Get(this.templatePath.Split(new[] { '/' })));
        }

        [Test]
        public void ShouldContainASelfLink()
        {
            var link = ((IEnumerable<dynamic>)this.jsonResponse.links).FirstOrDefault(l => l.rel == "self");

            Assert.IsNotNull(link);
        }

        [Test]
        public void ShouldHaveCorrectUrlInSelfLink()
        {
            var link = ((IEnumerable<dynamic>)this.jsonResponse.links).FirstOrDefault(l => l.rel == "self");

            ((string)link.href).Should().Be("/_kola/templates/test/path");
        }

        [Test]
        public void ShouldContainAPreviewLink()
        {
            var link = ((IEnumerable<dynamic>)this.jsonResponse.links).FirstOrDefault(l => l.rel == "preview");

            Assert.IsNotNull(link);
        }

        [Test]
        public void ShouldHaveCorrectUrlInPreviewLink()
        {
            var link = ((IEnumerable<dynamic>)this.jsonResponse.links).FirstOrDefault(l => l.rel == "preview");

            ((string)link.href).Should().Be("/_kola/preview/test/path");
        }
    }
}
