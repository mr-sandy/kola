namespace Integration.Tests.Nancy.Modules.RenderingModuleTests
{
    using System.Collections.Generic;

    using global::Nancy;
    using global::Nancy.Testing;
    using global::Nancy.ViewEngines;
    using global::Nancy.ViewEngines.Razor;

    using Kola.Configuration;
    using Kola.Domain.Composition;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;
    using Kola.Nancy;
    using Kola.Nancy.Modules;
    using Kola.Nancy.Processors;
    using Kola.Persistence;
    using Kola.Service.Services;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected IContentRepository ContentRepository { get; set; }

        protected IComponentSpecificationLibrary ComponentLibrary { get; set; }

        protected IWidgetSpecificationRepository WidgetRepository { get; set; }

        protected IPluginContextProvider PluginContextProvider { get; set; }

        protected IRendererFactory RendererFactory { get; set; }


        [SetUp]
        public void SetUpBase()
        {
            this.ContentRepository = MockRepository.GenerateMock<IContentRepository>();
            this.ComponentLibrary = MockRepository.GenerateMock<IComponentSpecificationLibrary>();
            this.WidgetRepository = MockRepository.GenerateMock<IWidgetSpecificationRepository>();
            this.RendererFactory = MockRepository.GenerateMock<IRendererFactory>();
            this.PluginContextProvider = MockRepository.GenerateStub<IPluginContextProvider>();

            this.SetUpAtom("atom1");
            this.SetUpContainer("container1");


            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.ContentRepository);
                        with.Dependency(this.ComponentLibrary);
                        with.Dependency(this.WidgetRepository);
                        with.Dependency(this.PluginContextProvider);
                        with.ResponseProcessor<PageInstanceResultProcessor>();
                        with.ResponseProcessor<ComponentInstanceResultProcessor>();
                        with.Dependency<RenderingService>();
                        with.Module<RenderingModule>();
                        with.ViewEngine<RazorViewEngine>();
                        with.ViewLocationProvider<ResourceViewLocationProvider>();

                        ResourceViewLocationProvider.RootNamespaces.Clear();
                        ResourceViewLocationProvider.RootNamespaces.Add(typeof(KolaNancyBootstrapper).Assembly, "Kola.Nancy");
                        ResourceViewLocationProvider.RootNamespaces.Add(typeof(ContextBase).Assembly, "Integration.Tests.Nancy.Modules.RenderingModuleTests.Views");
                    });

            KolaConfigurationRegistry.RegisterRenderer(new MultiRenderer(this.RendererFactory));

            bootstrapper.BeforeRequest = FakeOwinEnvironment();

            this.Browser = new Browser(bootstrapper);
        }

        private static BeforePipeline FakeOwinEnvironment()
        {
            var pipeline = new BeforePipeline();

            pipeline.AddItemToStartOfPipeline(
                context =>
                    {
                        context.Items.Add("OWIN_REQUEST_ENVIRONMENT", new Dictionary<string, object>());
                        return context.Response;
                    });

            return pipeline;
        }

        private void SetUpAtom(string name)
        {
            var specification = new AtomSpecification(name) { ViewName = name };

            this.ComponentLibrary.Stub(l => l.Lookup(name)).Return(specification);

            this.RendererFactory.Stub(f => f.GetAtomRenderer(name)).Return(new DefaultRenderer(specification));
        }

        private void SetUpContainer(string name)
        {
            var specification = new ContainerSpecification(name) { ViewName = name };

            this.ComponentLibrary.Stub(l => l.Lookup(name)).Return(specification);

            this.RendererFactory.Stub(f => f.GetContainerRenderer(name)).Return(new DefaultRenderer(specification));
        }
    }
}