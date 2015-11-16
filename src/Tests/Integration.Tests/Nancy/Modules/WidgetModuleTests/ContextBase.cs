namespace Integration.Tests.Nancy.Modules.WidgetModuleTests
{
    using global::Nancy.Responses.Negotiation;
    using global::Nancy.Testing;

    using Kola.Domain.Composition;
    using Kola.Nancy.Modules;
    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected IWidgetSpecificationRepository WidgetSpecificationRepository { get; set; }

        protected IComponentSpecificationLibrary ComponentLibrary { get; set; }

        [SetUp]
        public void SetUpBase()
        {
            this.WidgetSpecificationRepository = MockRepository.GenerateMock<IWidgetSpecificationRepository>();
            this.ComponentLibrary = MockRepository.GenerateMock<IComponentSpecificationLibrary>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependencies(new object[] { this.WidgetSpecificationRepository, this.ComponentLibrary });
                        with.ResponseProcessor<JsonProcessor>();
                        with.Module<WidgetModule>();
                    });

            this.Browser = new Browser(bootstrapper);
        }
    }
}