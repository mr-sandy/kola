namespace Unit.Tests.Rendering
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Configuration;
    using Kola.Configuration.Plugins;
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;
    using Kola.Nancy;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Unit.Tests.Rendering.Framework;

    public class WhenRenderingAPage
    {
        private string result;

        [SetUp]
        public void EstablishContext()
        {
            var handlerFactory = MockRepository.GenerateStub<IRendererFactory>();
            handlerFactory.Stub(h => h.GetAtomRenderer(Arg<string>.Is.Anything)).Return(new DefaultRenderer());
            handlerFactory.Stub(h => h.GetContainerRenderer(Arg<string>.Is.Anything)).Return(new DefaultRenderer());

            var renderer = new MultiRenderer(handlerFactory);

            NancyKolaConfigurationRegistry.Instance = new KolaConfiguration(renderer, Enumerable.Empty<PluginConfiguration>());

            var page =
                new PageInstance(
                    new ComponentInstance[]
                        {
                            new AtomInstance(new[] { 0 }, "atom1", Enumerable.Empty<ParameterInstance>()),
                            new AtomInstance(new[] { 1 }, "atom2", Enumerable.Empty<ParameterInstance>()),
                            new ContainerInstance(new[] { 2 }, "container1", null, new[] { new AtomInstance(new[] { 2, 0 }, "atom3", Enumerable.Empty<ParameterInstance>()) })
                        });

            var viewFactory = new TestViewFactory(renderer);
            var viewHelper = new TestViewHelper(viewFactory);


            var renderedPage = renderer.Render(page);
            this.result = renderedPage.ToHtml(viewHelper);
        }

        [Test]
        public void ShouldReturnAResult()
        {
            this.result.Should().NotBeNull();
        }

        [Test]
        public void ResultShouldIncludeHtmlForAtom1()
        {
            this.result.Should().Contain("<atom1/>");
        }

        [Test]
        public void ResultShouldIncludeHtmlForAtom2()
        {
            this.result.Should().Contain("<atom2/>");
        }

        [Test]
        public void ResultShouldIncludeHtmlForStartOfContainer1()
        {
            this.result.Should().Contain("<container1>");
        }

        [Test]
        public void ResultShouldIncludeHtmlForEndOfContainer1()
        {
            this.result.Should().Contain("</container1>");
        }

        [Test]
        public void ResultShouldIncludeHtmlForAtom3()
        {
            this.result.Should().Contain("<atom3/>");
        }
    }
}