namespace Integration.Tests.Nancy.Modules.RenderingModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    using global::Nancy;
    using global::Nancy.Testing;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPage : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var page = new PageInstance(new[] { new AtomInstance("atom1", Enumerable.Empty<ParameterInstance>()) });

            var atom1Handler = MockRepository.GenerateMock<IHandler<AtomInstance>>();
            atom1Handler.Stub(h => h.Render(Arg<AtomInstance>.Is.Anything)).Return(new Result(h => "<atom1/>"));

            this.PageHandler.Stub(h => h.GetPage(Arg<IEnumerable<string>>.Is.Anything)).Return(page);
            this.HandlerFactory.Stub(f => f.GetAtomHandler(Arg<string>.Is.Anything)).Return(atom1Handler);

            this.Response = this.Browser.Get("/", with => with.Header("Accept", "text/html"));
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnHtml()
        {
            this.Response.Body.AsString().Should().Contain("<atom1/>");
        }
    }
}
