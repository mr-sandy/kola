namespace Integration.Tests.Nancy.Modules.ComponentTypesModuleSpecs
{
    using Kola.Nancy;
    using Kola.Nancy.Modules;

    using global::Nancy.Testing;

    using NUnit.Framework;

    using Rhino.Mocks;

    internal abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected IComponentRegistry ComponentTypeRepository { get; set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.ComponentTypeRepository = MockRepository.GenerateMock<IComponentRegistry>();

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