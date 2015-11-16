namespace Integration.Tests.Nancy.Modules.ComponentTypesModuleTests
{
    using global::Nancy.Responses.Negotiation;
    using global::Nancy.Testing;

    using Kola.Domain.Composition;
    using Kola.Nancy.Modules;

    using NUnit.Framework;

    using Rhino.Mocks;

    internal abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected IComponentSpecificationLibrary ComponentLibrary { get; set; }

        [SetUp]
        public void SetUpBase()
        {
            this.ComponentLibrary = MockRepository.GenerateMock<IComponentSpecificationLibrary>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.ComponentLibrary);
                    with.ResponseProcessor<JsonProcessor>();
                    with.Module<ComponentTypeModule>();
                });

            this.Browser = new Browser(bootstrapper);
        }
    }
}