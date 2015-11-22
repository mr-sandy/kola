namespace Integration.Tests.Nancy.Modules.RenderingModuleTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using global::Nancy;

    using Kola.Domain.Composition;
    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingARedirect : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var redirect = new FindContentResult(new Redirect("new/location"), null);

            this.ContentRepository.Stub(r => r.FindContent(Arg<IEnumerable<string>>.List.Equal(new[] { "test", "path" })))
                .Return(new[] { redirect });

            this.Response = this.Browser.Get("/test/path", with => with.Header("Accept", "text/html"));
        }

        [Test]
        public void ShouldReturnMovedPermanently()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.MovedPermanently);
        }

        [Test]
        public void ShouldIncludeLocationHeader()
        {
            this.Response.Headers["location"].Should().Be("new/location");
        }
    }
}