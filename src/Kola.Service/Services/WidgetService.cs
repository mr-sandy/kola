namespace Kola.Service.Services
{
    using Kola.Domain.Specifications;
    using Kola.Persistence;
    using Kola.Service.Services.Results;

    public class WidgetService : IWidgetService
    {
        private readonly IWidgetSpecificationRepository widgetSpecificationRepository;

        public WidgetService(IWidgetSpecificationRepository widgetSpecificationRepository)
        {
            this.widgetSpecificationRepository = widgetSpecificationRepository;
        }

        public IResult<WidgetSpecification> CreateWidget(string widgetName)
        {
            if (this.widgetSpecificationRepository.Find(widgetName) != null)
            {
                return new ConflictResult<WidgetSpecification>();
            }

            var widgetSpecification = new WidgetSpecification(widgetName);

            this.widgetSpecificationRepository.Add(widgetSpecification);

            return new CreatedResult<WidgetSpecification>(widgetSpecification);
        }
    }
}