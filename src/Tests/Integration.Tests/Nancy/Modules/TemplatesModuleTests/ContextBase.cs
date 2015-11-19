namespace Integration.Tests.Nancy.Modules.TemplatesModuleTests
{
    using global::Nancy.Testing;

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

        [SetUp]
        public void SetUpBase()
        {
            this.ContentRepository = MockRepository.GenerateMock<IContentRepository>();
            this.ComponentLibrary = MockRepository.GenerateMock<IComponentSpecificationLibrary>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependencies(new object[] { this.ContentRepository, this.ComponentLibrary });
                        with.Dependency<TemplateResourceBuilder>();
                        with.Dependency<AmendmentDetailsResourceBuilder>();
                        with.Dependency<AmendmentsDetailsResourceBuilder>();
                        with.Dependency<UndoAmendmentDetailsResourceBuilder>();
                        with.Dependency<ComponentDetailsResourceBuilder>();
                        with.ResponseProcessor<TemplateResultProcessor>();
                        with.ResponseProcessor<AmendmentDetailsResultProcessor>();
                        with.ResponseProcessor<AmendmentsDetailsResultProcessor>();
                        with.ResponseProcessor<UndoAmendmentDetailsResultProcessor>();
                        with.ResponseProcessor<ComponentDetailsResultProcessor>();
                        with.Dependency<TemplateService>();
                        with.Module<TemplateModule>();
                    });

            this.Browser = new Browser(bootstrapper);
        }
    }
}