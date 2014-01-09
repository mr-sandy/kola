namespace Integration.Tests.Nancy.Modules.ComponentTypesModuleSpecs
{
    using Kola.Domain;
    using Kola.Nancy;
    using Kola.Nancy.Modules;

    using global::Nancy.Testing;

    using NUnit.Framework;

    using Rhino.Mocks;

    internal abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected IComponentLibrary ComponentLibrary { get; set; }

        [SetUp]
        public void EstablishBaseContext()
        {
            this.ComponentLibrary = MockRepository.GenerateMock<IComponentLibrary>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependencies(new object[] { this.ComponentLibrary });
                    with.Module<ComponentTypeModule>();
                });

            this.Browser = new Browser(bootstrapper);
        }
    }
}