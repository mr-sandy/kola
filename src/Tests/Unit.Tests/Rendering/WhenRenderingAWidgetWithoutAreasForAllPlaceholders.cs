namespace Unit.Tests.Rendering
{
    using System;
    using System.Linq;

    using FluentAssertions;

    using Kola.Configuration;
    using Kola.Configuration.Plugins;
    using Kola.Domain.Composition;
    using Kola.Domain.Instances.Building;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenRenderingAWidgetWithoutAreasForAllPlaceholders
    {
        private IResult result;

        private IViewHelper viewHelper;

        [SetUp]
        public void EstablishContext()
        {
            var placeholder1 = new Placeholder("area 1");
            var placeholder2 = new Placeholder("area 2");
            var widgetSpecification = new WidgetSpecification("widget");
            widgetSpecification.Insert(0, placeholder1);
            widgetSpecification.Insert(1, placeholder2);

            var area = new Area("area 1");
            var widget = new Widget("widget", new[] { area });
            
            var buildContext = new BuildContext
                {
                    WidgetSpecificationFinder = w => widgetSpecification
                };

            var instance = widget.Build(new[] { 0 }, buildContext);

            var rendererFactory = MockRepository.GenerateStub<IRendererFactory>();
            this.viewHelper = MockRepository.GenerateStub<IViewHelper>();
            var multiRenderer = new MultiRenderer(rendererFactory);

            KolaConfigurationRegistry.Register(new KolaConfiguration(multiRenderer, Enumerable.Empty<PluginConfiguration>()));

            this.result = instance.Render(multiRenderer);
        }

        [Test]
        public void ShouldNotThrowAnExceptionWhenConvertingResultToHtml()
        {
            Action a = () => this.result.ToHtml(this.viewHelper);
            a.ShouldNotThrow();
        }
    }
}