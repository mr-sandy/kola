namespace Service.Tests.RenderingServiceTests
{
    using Kola.Domain.Composition;
    using Kola.Persistence;
    using Kola.Service.Services;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected ITemplateRepository TemplateRepository;
        protected IWidgetSpecificationRepository WidgetSpecificationRepository;
        protected IComponentSpecificationLibrary ComponentLibrary;

        protected RenderingService RenderingService;

        [SetUp]
        public void SetUpBase()
        {
            this.TemplateRepository = MockRepository.GenerateStub<ITemplateRepository>();
            this.WidgetSpecificationRepository = MockRepository.GenerateStub<IWidgetSpecificationRepository>();
            this.ComponentLibrary = MockRepository.GenerateStub<IComponentSpecificationLibrary>();

            this.RenderingService = new RenderingService(this.TemplateRepository, this.WidgetSpecificationRepository, this.ComponentLibrary);
        }
    }
}
