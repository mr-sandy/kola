namespace Unit.Tests.Rendering
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Configuration;
    using Kola.Configuration.Plugins;
    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Unit.Tests.Rendering.Framework;

    public class WhenRenderingAPage
    {
        private string result;

        [SetUp]
        public void EstablishContext()
        {
            var atom1Specification = MockRepository.GenerateStub<IPluginComponentSpecification<IComponentWithProperties>>();
            var atom2Specification = MockRepository.GenerateStub<IPluginComponentSpecification<IComponentWithProperties>>();
            var atom3Specification = MockRepository.GenerateStub<IPluginComponentSpecification<IComponentWithProperties>>();
            var containerSpecification = MockRepository.GenerateStub<IPluginComponentSpecification<IComponentWithProperties>>();

            atom1Specification.ViewName = "Atom1View";
            atom2Specification.ViewName = "Atom2View";
            atom3Specification.ViewName = "Atom3View";
            containerSpecification.ViewName = "Container1View";

            var handlerFactory = MockRepository.GenerateStub<IRendererFactory>();
            handlerFactory.Stub(h => h.GetAtomRenderer("atom1")).Return(new DefaultRenderer(atom1Specification));
            handlerFactory.Stub(h => h.GetAtomRenderer("atom2")).Return(new DefaultRenderer(atom2Specification));
            handlerFactory.Stub(h => h.GetAtomRenderer("atom3")).Return(new DefaultRenderer(atom3Specification));
            handlerFactory.Stub(h => h.GetContainerRenderer("container1")).Return(new DefaultRenderer(containerSpecification));

            var renderer = new MultiRenderer(handlerFactory);

            KolaConfigurationRegistry.Register(new KolaConfiguration(renderer, Enumerable.Empty<PluginConfiguration>()));

            var page =
                new PageInstance(
                    new ComponentInstance[]
                        {
                            new AtomInstance(new[] { 0 }, "atom1", Enumerable.Empty<PropertyInstance>()),
                            new AtomInstance(new[] { 1 }, "atom2", Enumerable.Empty<PropertyInstance>()),
                            new ContainerInstance(new[] { 2 }, "container1", null, new[] { new AtomInstance(new[] { 2, 0 }, "atom3", Enumerable.Empty<PropertyInstance>()) })
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
            this.result.Should().Contain("<Atom1View/>");
        }

        [Test]
        public void ResultShouldIncludeHtmlForAtom2()
        {
            this.result.Should().Contain("<Atom2View/>");
        }

        [Test]
        public void ResultShouldIncludeHtmlForStartOfContainer1()
        {
            this.result.Should().Contain("<Container1View>");
        }

        [Test]
        public void ResultShouldIncludeHtmlForEndOfContainer1()
        {
            this.result.Should().Contain("</Container1View>");
        }

        [Test]
        public void ResultShouldIncludeHtmlForAtom3()
        {
            this.result.Should().Contain("<Atom3View/>");
        }
    }
}