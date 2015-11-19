namespace Integration.Tests.Nancy.Modules.RenderingModuleTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using global::Nancy;
    using global::Nancy.Testing;

    using Kola.Domain.Composition;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPageForPreview : ContextBase
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

            this.ContentRepository.Stub(r => r.Get(Arg<IEnumerable<string>>.List.Equal(new[] { "test", "path" })))
                .Return(template);

            this.Response = this.Browser.Get("/test/path",
                with =>
                    {
                        with.Header("Accept", "text/html");
                        with.Query("preview", "y");
                    });
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnHtml()
        {
            this.Response.Body.AsString().Should().Contain("<!--/0-start--><container1>\r\n<!--/0/0-start--><atom1/><!--/0/0-end-->\r\n</ container1><!--/0-end-->");
        }

        [Test]
        public void ShouldNotBeCacheable()
        {
            this.Response.Headers["Cache-Control"].Should().Be("no-cache");
        }
    }
}