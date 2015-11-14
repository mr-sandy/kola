﻿namespace Integration.Tests.Nancy.Modules.RenderingModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    using global::Nancy;
    using global::Nancy.Testing;

    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPage : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var renderingInstructions = MockRepository.GenerateStub<IRenderingInstructions>();

            var atom1Handler = MockRepository.GenerateMock<IRenderer<AtomInstance>>();
            atom1Handler.Stub(h => h.Render(Arg<AtomInstance>.Is.Anything)).Return(new Result(h => "<atom1/>"));

            var page = new PageInstance(new[] { new AtomInstance(new[] { 0 }, renderingInstructions, "atom1", Enumerable.Empty<PropertyInstance>()) });

            this.RenderingService.Stub(h => h.GetPage(Arg<IEnumerable<string>>.Is.Anything, Arg<bool>.Is.Anything)).Return(new SuccessResult<PageInstance>(page));
            this.HandlerFactory.Stub(f => f.GetAtomRenderer(Arg<string>.Is.Anything)).Return(atom1Handler);

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
