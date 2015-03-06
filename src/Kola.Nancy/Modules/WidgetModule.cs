namespace Kola.Nancy.Modules
{
    using Kola.Domain.Specifications;
    using Kola.Persistence;

    using global::Nancy;

    using Kola.Service.ResourceBuilding;

    public class WidgetModule : NancyModule
    {
        private readonly IWidgetSpecificationRepository widgetSpecificationRepository;

        public WidgetModule(IWidgetSpecificationRepository widgetSpecificationRepository)
        {
            this.widgetSpecificationRepository = widgetSpecificationRepository;
            this.Put["/_kola/widgets/{widgetName}", AcceptHeaderFilters.NotHtml] = p => this.PutWidget(p.widgetName);
        }

        private dynamic PutWidget(string widgetName)
        {
            if (this.widgetSpecificationRepository.Find(widgetName) != null)
            {
                return HttpStatusCode.Conflict;
            }

            var widgetSpecification = new WidgetSpecification(widgetName);

            this.widgetSpecificationRepository.Add(widgetSpecification);

            var resource = new ComponentTypeResourceBuilder().Build(widgetSpecification);

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json")
                .WithStatusCode(HttpStatusCode.Created)
                .WithHeader("location", string.Format("/widgets/{0}", widgetName));
        }
    }
}