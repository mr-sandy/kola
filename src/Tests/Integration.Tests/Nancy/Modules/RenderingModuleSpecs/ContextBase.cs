namespace Integration.Tests.Nancy.Modules.RenderingModuleSpecs
{
    using Kola.Configuration;
    using Kola.Nancy;
    using Kola.Nancy.Modules;
    using Kola.Rendering;

    using global::Nancy.Testing;
    using global::Nancy.ViewEngines;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected IPageHandler PageHandler { get; set; }

        protected IHandlerFactory HandlerFactory { get; set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.PageHandler = MockRepository.GenerateMock<IPageHandler>();
            this.HandlerFactory = MockRepository.GenerateMock<IHandlerFactory>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        ResourceViewLocationProvider.RootNamespaces.Clear();
                        ResourceViewLocationProvider.RootNamespaces.Add(typeof(IPageHandler).Assembly, "Kola.Nancy.Views");

                        with.Dependency(this.PageHandler);
                        with.Module<RenderingModule>();
                        with.ViewLocationProvider(new ResourceViewLocationProvider());
                    });

            NancyKolaConfigurationRegistry.Instance = new KolaConfiguration(new KolaEngine(new Renderer(this.HandlerFactory)), null);
            this.Browser = new Browser(bootstrapper);
        }
    }
}