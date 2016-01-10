namespace Kola.Nancy.Modules
{
    using global::Nancy;
    using global::Nancy.ModelBinding;

    using Kola.Configuration;
    using Kola.Domain.Composition.Amendments;
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
            : base("/_kola/templates")
        {
            this.templateService = templateService;
            this.kolaConfigurationRegistry = kolaConfigurationRegistry;

            this.Get["/"] = p => this.GetTemplate();
            this.Put["/"] = p => this.PutTemplate();
            this.Get["/components"] = p => this.GetComponent();
            this.Get["/amendments"] = p => this.GetAmendments();
            this.Post["/amendments"] = p => this.PostAmendment();
            this.Put["/amendments"] = p => this.ApplyAmendments();
            this.Delete["/amendments"] = p => this.UndoAmendment();
        }

        private dynamic GetTemplate()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            return
                this.Negotiate.WithView("Application")
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

        private dynamic PostAmendment()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();
            var amendment = new AmendmentBuilder(this).BuildAmendment(query.AmendmentType);

            var result = this.templateService.AddAmendment(path, amendment);

            return this.Negotiate.WithModel(result);
        }

        private dynamic ApplyAmendments()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            var result = this.templateService.ApplyAmendments(path);

            return this.Negotiate.WithModel(result);
        }

        private dynamic UndoAmendment()
        {
            var query = this.Bind<TemplateQuery>();
            var path = query.TemplatePath.ParsePath();

            var result = this.templateService.UndoAmendment(path);

            return this.Negotiate.WithModel(result);
        }
    }
}