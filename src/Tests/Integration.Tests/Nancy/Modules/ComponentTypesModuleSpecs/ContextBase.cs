namespace Integration.Tests.Nancy.Modules.ComponentTypesModuleSpecs
{
    using Kola.Nancy.Modules;

    using global::Nancy.Testing;

    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected IComponentTypeRepository ComponentTypeRepository { get; set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.ComponentTypeRepository = MockRepository.GenerateMock<IComponentTypeRepository>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependencies(new object[] { this.ComponentTypeRepository });
                    with.Module<ComponentTypeModule>();
                });

            this.Browser = new Browser(bootstrapper);
        }
    }
}