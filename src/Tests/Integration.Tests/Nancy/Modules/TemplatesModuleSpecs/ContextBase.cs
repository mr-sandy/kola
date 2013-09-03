namespace Integration.Tests.Nancy.Modules.TemplatesModuleSpecs
{
    using Kola.Nancy.Modules;
    using Kola.Persistence;
    using global::Nancy.Testing;
    using NUnit.Framework;
    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected ITemplateRepository TemplateRepository { get; set; }

        protected IComponentFactory ComponentFactory { get; set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.TemplateRepository = MockRepository.GenerateMock<ITemplateRepository>();

            this.ComponentFactory = MockRepository.GenerateMock<IComponentFactory>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependencies(new object[] { this.TemplateRepository, this.ComponentFactory });
                        with.Module<TemplateModule>();
                    });

            this.Browser = new Browser(bootstrapper);
        }
    }
}