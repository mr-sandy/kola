namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using global::Nancy.ModelBinding;

    using Kola.Nancy.Extensions;
    using Kola.Nancy.Models;
    using Kola.Service.Services;

    public class WidgetModule : NancyModule
    {
        private readonly IWidgetService widgetService;

        public WidgetModule(IWidgetService widgetService) 
            : base("/_kola/widgets")
        {
            this.widgetService = widgetService;

            this.Get["/"] = p => this.GetWidget(p.widgetName);
            this.Put["/"] = p => this.PutWidget(p.widgetName);
            this.Get["/components"] = p => this.GetComponent();
        }

        private dynamic GetWidget(string widgetName)
        {
            var query = this.Bind<WidgetQuery>();

            var result = this.widgetService.GetWidget(query.WidgetName);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PutWidget(string widgetName)
        {
            var query = this.Bind<WidgetQuery>();

            var result = this.widgetService.CreateWidget(query.WidgetName);

            return this.Negotiate.WithModel(result);
        }

        private dynamic GetComponent()
        {
            var query = this.Bind<WidgetQuery>();
            var componentPath = query.ComponentPath.ParseComponentPath();

            var result = this.widgetService.GetComponent(query.WidgetName, componentPath);

            return this.Negotiate.WithModel(result);
        }

    }
}