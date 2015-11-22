namespace Integration.Tests.Nancy.Modules.RenderingModuleTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using global::Nancy;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPageThatDoesntExist : ContextBase
    {
        [SetUp]
        public void SetUp()
        {

            this.ContentRepository.Stub(r => r.FindContent(Arg<IEnumerable<string>>.Is.Anything)).Return(null);

            this.Response = this.Browser.Get("/", with => with.Header("Accept", "text/html"));
        }

        [Test]
        public void ShouldReturnNotFound()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}