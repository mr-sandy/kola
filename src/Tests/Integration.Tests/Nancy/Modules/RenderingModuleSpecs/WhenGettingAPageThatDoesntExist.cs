namespace Integration.Tests.Nancy.Modules.RenderingModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using global::Nancy;
    using global::Nancy.Testing;

    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;
    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPageThatDoesntExist : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {

            this.RenderingService.Stub(h => h.GetPage(Arg<IEnumerable<string>>.Is.Anything, Arg<bool>.Is.Anything)).Return(new NotFoundResult<PageInstance>());

            this.Response = this.Browser.Get("/", with => with.Header("Accept", "text/html"));
        }

        [Test]
        public void ShouldReturnNotFound()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}