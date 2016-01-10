namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using global::Nancy.ModelBinding;

    using Kola.Nancy.Extensions;
    using Kola.Nancy.Models;
    using Kola.Service.Services;

    public class WidgetSpecificationModule : NancyModule
    {
        private readonly IWidgetSpecificationService widgetSpecificationService;

        public WidgetSpecificationModule(IWidgetSpecificationService widgetSpecificationService) 
            : base("/_kola/widgets")
        {
            this.widgetSpecificationService = widgetSpecificationService;

            this.Get["/"] = p => this.GetWidget();
            this.Put["/"] = p => this.PutWidget();
            this.Get["/components"] = p => this.GetComponent();
            this.Get["/amendments"] = p => this.GetAmendments();
            this.Post["/amendments"] = p => this.PostAmendment();
            this.Put["/amendments"] = p => this.ApplyAmendments();
            this.Delete["/amendments"] = p => this.UndoAmendment();
        }

        private dynamic GetWidget()
        {
            var query = this.Bind<WidgetQuery>();

            var result = this.widgetSpecificationService.GetWidgetSpecification(query.Name);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PutWidget()
        {
            var query = this.Bind<WidgetQuery>();

            var result = this.widgetSpecificationService.CreateWidgetSpecification(query.Name);

            return this.Negotiate.WithModel(result);
        }

        private dynamic GetComponent()
        {
            var query = this.Bind<WidgetQuery>();
            var componentPath = query.ComponentPath.ParseComponentPath();

            var result = this.widgetSpecificationService.GetComponent(query.Name, componentPath);

            return this.Negotiate.WithModel(result);
        }

        private dynamic GetAmendments()
        {
            var query = this.Bind<WidgetQuery>();

            var result = this.widgetSpecificationService.GetAmendments(query.Name);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PostAmendment()
        {
            var query = this.Bind<WidgetQuery>();
            var amendment = new AmendmentBuilder(this).BuildAmendment(query.AmendmentType);

            var result = this.widgetSpecificationService.AddAmendment(query.Name, amendment);

            return this.Negotiate.WithModel(result);
        }

        private dynamic ApplyAmendments()
        {
            var query = this.Bind<WidgetQuery>();

            var result = this.widgetSpecificationService.ApplyAmendments(query.Name);

            return this.Negotiate.WithModel(result);
        }

        private dynamic UndoAmendment()
        {
            var query = this.Bind<WidgetQuery>();

            var result = this.widgetSpecificationService.UndoAmendment(query.Name);

            return this.Negotiate.WithModel(result);
        }
    }
}