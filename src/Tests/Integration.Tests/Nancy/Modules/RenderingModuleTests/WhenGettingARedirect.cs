namespace Integration.Tests.Nancy.Modules.RenderingModuleTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using global::Nancy;

    using Kola.Domain.Composition;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingARedirect : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var redirect = new Redirect("new/location");

            this.ContentRepository.Stub(r => r.Get(Arg<IEnumerable<string>>.List.Equal(new[] { "test", "path" })))
                .Return(redirect);

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