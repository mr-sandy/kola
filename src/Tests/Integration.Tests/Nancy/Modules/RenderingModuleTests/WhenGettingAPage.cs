namespace Integration.Tests.Nancy.Modules.RenderingModuleTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using global::Nancy;
    using global::Nancy.Testing;

    using Kola.Domain.Composition;
    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPage : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            // template:
            // - container1
            //   - atom1
            var template = new Template(
                new[] { "test", "path" },
                new[] { new Container("container1", null, new[] { new Atom("atom1") }) });

            this.ContentRepository.Stub(r => r.FindContent(Arg<IEnumerable<string>>.List.Equal(new[] { "test", "path" })))
                .Return(new [] { new FindContentResult(template, null)});

            this.Response = this.Browser.Get("/test/path", with => with.Header("Accept", "text/html"));
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnHtml()
        {
            this.Response.Body.AsString().Should().Contain("<container1>\r\n<atom1/>\r\n</ container1>");
        }

        [Test]
        public void ShouldBeCacheable()
        {
            this.Response.Headers["Cache-Control"].Should().Be("public, max-age=600");
        }
    }
}