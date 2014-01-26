namespace Kola.Nancy.Modules
{
    using global::Nancy;

    using Kola.Domain.Specifications;
    using Kola.Extensions;
    using Kola.Persistence;

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

            return this.Response.AsJson(widgetSpecification.ToResource())
                .WithStatusCode(HttpStatusCode.Created)
                .WithHeader("location", string.Format("/widgets/{0}", widgetName));
        }
    }
}