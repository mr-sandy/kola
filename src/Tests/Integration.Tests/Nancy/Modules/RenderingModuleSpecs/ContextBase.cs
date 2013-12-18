namespace Integration.Tests.Nancy.Modules.RenderingModuleSpecs
{
    using global::Nancy.ViewEngines;

    using Kola;
    using Kola.Nancy.Modules;
    using Kola.Persistence;

    using global::Nancy.Testing;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected IPageHandler PageHandler { get; set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.PageHandler = MockRepository.GenerateMock<IPageHandler>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        ResourceViewLocationProvider.RootNamespaces.Add(typeof(IPageHandler).Assembly, "Kola.Nancy");

                        with.Dependency(this.PageHandler);
                        with.Module<RenderingModule>();
                        with.ViewLocationProvider(new ResourceViewLocationProvider());
                    });

            this.Browser = new Browser(bootstrapper);
        }
    }
}