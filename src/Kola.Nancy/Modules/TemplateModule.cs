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
            : base("/_kola/templates/{templatePath*}")
        {
            this.templateService = templateService;
            this.kolaConfigurationRegistry = kolaConfigurationRegistry;

            this.Get["/"] = p => this.GetTemplate(p.templatePath);
            this.Put["/"] = p => this.PutTemplate(p.templatePath);
            this.Get["/_components/{componentPath*}"] = p => this.GetComponent(p.templatePath, p.componentPath);
            this.Get["/_amendments"] = p => this.GetAmendments(p.templatePath);
            this.Post["/_amendments/addComponent"] = p => this.PostAmendment<AddComponentAmendmentResource>(p.templatePath);
            this.Post["/_amendments/moveComponent"] = p => this.PostAmendment<MoveComponentAmendmentResource>(p.templatePath);
            this.Post["/_amendments/removeComponent"] = p => this.PostAmendment<RemoveComponentAmendmentResource>(p.templatePath);
            this.Post["/_amendments/duplicateComponent"] = p => this.PostAmendment<DuplicateComponentAmendmentResource>(p.templatePath);
            this.Post["/_amendments/clearProperty"] = p => this.PostAmendment<ClearPropertyAmendmentResource>(p.templatePath);
            this.Post["/_amendments/setPropertyFixed"] = p => this.PostAmendment<SetPropertyFixedAmendmentResource>(p.templatePath);
            this.Post["/_amendments/setPropertyInherited"] = p => this.PostAmendment<SetPropertyInheritedAmendmentResource>(p.templatePath);
            this.Post["/_amendments/setComment"] = p => this.PostAmendment<SetCommentAmendmentResource>(p.templatePath);
            this.Post["/_amendments/apply"] = p => this.PostApplyAmendments(p.templatePath);
            this.Post["/_amendments/undo"] = p => this.PostUndoAmendment(p.templatePath);
        }

        private dynamic GetTemplate(string rawPath)
        {
            var path = rawPath.ParsePath();

            return this.Negotiate
                .WithView("Application")
                .WithMediaRangeModel("application/json", () => this.templateService.GetTemplate(path))
                .WithMediaRangeModel("text/html", () => ApplicationModel.Build(this.kolaConfigurationRegistry));
        }

        private dynamic GetAmendments(string rawPath)
        {
            var path = rawPath.ParsePath();

            var result = this.templateService.GetAmendments(path);

            return this.Negotiate.WithModel(result);
        }

        private dynamic GetComponent(string rawTemplatePath, string rawComponentPath)
        {
            var templatePath = rawTemplatePath.ParsePath();
            var componentPath = rawComponentPath.ParseComponentPath();

            var result = this.templateService.GetComponent(templatePath, componentPath);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PutTemplate(string rawPath)
        {
            var path = rawPath.ParsePath();

            var result = this.templateService.CreateTemplate(path);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PostAmendment<T>(string rawPath)
            where T : AmendmentResource
        {
            var path = rawPath.ParsePath();
            var amendment = new AmendmentDomainBuilder().Build(this.Bind<T>());

            var result = this.templateService.AddAmendment(path, amendment);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PostApplyAmendments(string rawPath)
        {
            var path = rawPath.ParsePath();

            var result = this.templateService.ApplyAmendments(path);

            return this.Negotiate.WithModel(result);
        }

        private dynamic PostUndoAmendment(string rawPath)
        {
            var path = rawPath.ParsePath();

            var result = this.templateService.UndoAmendment(path);

            return this.Negotiate.WithModel(result);
        }
    }
}