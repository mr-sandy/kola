namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using global::Nancy.ModelBinding;

    using Kola.Configuration;
    using Kola.Nancy.Extensions;
    using Kola.Nancy.Models;
    using Kola.Resources;
    using Kola.Service.DomainBuilding;
    using Kola.Service.Services;

    public class TemplateModule : NancyModule
    {
        private readonly ITemplateService templateService;
        private readonly IKolaConfigurationRegistry kolaConfigurationRegistry;

        public TemplateModule(ITemplateService templateService, IKolaConfigurationRegistry kolaConfigurationRegistry)
            : base("/_kola/template")
        {
            this.templateService = templateService;
            this.kolaConfigurationRegistry = kolaConfigurationRegistry;

            this.Get["/"] = p => this.GetTemplate();
            this.Put["/"] = p => this.PutTemplate();
            this.Get["/components"] = p => this.GetComponent();
            this.Get["/amendments"] = p => this.GetAmendments();
            this.Post["/amendments/addComponent"] = p => this.PostAmendment<AddComponentAmendmentResource>();
            this.Post["/amendments/moveComponent"] = p => this.PostAmendment<MoveComponentAmendmentResource>();
            this.Post["/amendments/removeComponent"] = p => this.PostAmendment<RemoveComponentAmendmentResource>();
            this.Post["/amendments/duplicateComponent"] = p => this.PostAmendment<DuplicateComponentAmendmentResource>();
            this.Post["/amendments/resetProperty"] = p => this.PostAmendment<ResetPropertyAmendmentResource>();
            this.Post["/amendments/setPropertyFixed"] = p => this.PostAmendment<SetPropertyFixedAmendmentResource>();
            this.Post["/amendments/setPropertyInherited"] = p => this.PostAmendment<SetPropertyInheritedAmendmentResource>();
            this.Post["/amendments/setComment"] = p => this.PostAmendment<SetCommentAmendmentResource>();
            this.Post["/amendments/apply"] = p => this.PostApplyAmendments();
            this.Post["/amendments/undo"] = p => this.PostUndoAmendment();
        }

        private dynamic GetTemplate()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            return this.Negotiate
                .WithView("Application")
                .WithMediaRangeModel("application/json", () => this.templateService.GetTemplate(path))
                .WithMediaRangeModel("text/html", () => ApplicationModel.Build(this.kolaConfigurationRegistry));
        }

        private dynamic GetAmendments()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            var result = this.templateService.GetAmendments(path);

            return this.Negotiate.WithModel(result);
        }

        private dynamic GetComponent()
        {
            var query = this.Bind<TemplateQuery>();
            var templatePath = query.TemplatePath.ParsePath();
            var componentPath = query.ComponentPath.ParseComponentPath();

            var result = this.templateService.GetComponent(templatePath, componentPath);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PutTemplate()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            var result = this.templateService.CreateTemplate(path);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PostAmendment<T>()
            where T : AmendmentResource
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();
            var amendment = new AmendmentDomainBuilder().Build(this.Bind<T>());

            var result = this.templateService.AddAmendment(path, amendment);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PostApplyAmendments()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            var result = this.templateService.ApplyAmendments(path);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PostUndoAmendment()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            var result = this.templateService.UndoAmendment(path);

            return this.Negotiate.WithModel(result);
        }
    }

    public class TemplateQuery
    {
        private string templatePath;
        private string componentPath;

        public string TemplatePath
        {
            get
            {
                return this.templatePath ?? string.Empty;
            }
            set
            {
                this.templatePath= value;
            }
        }

        public string ComponentPath
        {
            get
            {
                return this.componentPath ?? string.Empty;
            }
            set
            {
                this.componentPath = value;
            }
        }
    }
}