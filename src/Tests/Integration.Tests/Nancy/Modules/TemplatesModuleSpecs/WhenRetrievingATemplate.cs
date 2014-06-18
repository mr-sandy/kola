namespace Integration.Tests.Nancy.Modules.TemplatesModuleSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Kola.Domain.Composition;

    using global::Nancy;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenRetrievingATemplate : ContextBase
    {
        private string templatePath = @"test/path";

        [SetUp]
        public void EstablishContext()
        {
            var template = new Template(new[] { "test", "path" });

            this.TemplateRepository.Stub(r => r.Get(Arg<IEnumerable<string>>.Is.Anything)).Return(template);


            this.Response = this.Browser.Get(string.Format("/_kola/templates/{0}", this.templatePath), with => with.Header("Accept", "application/json"));
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
    }
}
