namespace Integration.Tests.Nancy.Modules.TemplatesModuleTests
{
    using global::Nancy.Testing;

    using Kola.Configuration;
    using Kola.Domain.Composition;
    using Kola.Nancy.Modules;
    using Kola.Nancy.Processors;
    using Kola.Persistence;
    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected Browser Browser { get; private set; }

        protected BrowserResponse Response { get; set; }

        protected IContentRepository ContentRepository { get; set; }

        protected IComponentSpecificationLibrary ComponentLibrary { get; set; }

        protected IKolaConfigurationRegistry KolaConfigurationRegistry { get; set; }

        [SetUp]
        public void SetUpBase()
        {
            this.ContentRepository = MockRepository.GenerateMock<IContentRepository>();
            this.ComponentLibrary = MockRepository.GenerateMock<IComponentSpecificationLibrary>();
            this.KolaConfigurationRegistry = MockRepository.GenerateMock<IKolaConfigurationRegistry>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.ContentRepository);
                        with.Dependency(this.ComponentLibrary);
                        with.Dependency(this.KolaConfigurationRegistry);
                        with.Dependency<TemplateResourceBuilder>();
                        with.Dependency<AmendmentDetailsResourceBuilder>();
                        with.Dependency<AmendmentsDetailsResourceBuilder>();
                        with.Dependency<UndoAmendmentDetailsResourceBuilder>();
                        with.Dependency<ComponentDetailsResourceBuilder>();
                        with.ResponseProcessor<TemplateJsonResultProcessor>();
                        with.ResponseProcessor<AmendmentDetailsJsonResultProcessor>();
                        with.ResponseProcessor<AmendmentsDetailsJsonResultProcessor>();
                        with.ResponseProcessor<UndoAmendmentDetailsJsonResultProcessor>();
                        with.ResponseProcessor<ComponentDetailsJsonResultProcessor>();
                        with.Dependency<TemplateService>();
                        with.Module<TemplateModule>();
                    });

            this.Browser = new Browser(bootstrapper);
        }
    }
}