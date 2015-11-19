namespace Kola.Nancy.Modules
{
    using global::Nancy;

    using Kola.Service.Services;

    public class WidgetModule : NancyModule
    {
        private readonly IWidgetService widgetService;

        public WidgetModule(IWidgetService widgetService)
        {
            this.widgetService = widgetService;

            this.Put["/_kola/widgets/{widgetName}"] = p => this.PutWidget(p.widgetName);
        }

        private dynamic PutWidget(string widgetName)
        {
            var result = this.widgetService.CreateWidget(widgetName);

            return this.Negotiate.WithModel(result);
        }
    }
}