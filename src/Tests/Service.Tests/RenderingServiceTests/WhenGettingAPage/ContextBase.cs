namespace Service.Tests.RenderingServiceTests.WhenGettingAPage
{
    using Kola.Domain.Composition;
    using Kola.Persistence;
    using Kola.Service.Services;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase
    {
        protected IContentRepository ContentRepository { get; set; }

        protected IWidgetSpecificationRepository WidgetSpecificationRepository { get; set; }

        protected IComponentSpecificationLibrary ComponentLibrary { get; set; }
        
        protected RenderingService RenderingService { get; set; }

        [SetUp]
        public void SetUpBase()
        {
            this.ContentRepository = MockRepository.GenerateStub<IContentRepository>();
            this.WidgetSpecificationRepository = MockRepository.GenerateStub<IWidgetSpecificationRepository>();
            this.ComponentLibrary = MockRepository.GenerateStub<IComponentSpecificationLibrary>();

            this.RenderingService = new RenderingService(this.ContentRepository, this.WidgetSpecificationRepository, this.ComponentLibrary);
        }
    }
}
