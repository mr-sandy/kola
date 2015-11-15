namespace Kola.Nancy.Modules
{
    using System.Linq;

    using global::Nancy;
    using global::Nancy.ModelBinding;

    using Kola.Domain.Composition;
    using Kola.Domain.Extensions;
    using Kola.Nancy.Extensions;
    using Kola.Persistence;
    using Kola.Resources;
    using Kola.Service.DomainBuilding;
    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services;

    // TODO {SC} Refactor bulk of code into a service independent of Nancy (add to the Kola.Services namespace); make this module as lightweight as possible
    public class TemplateModule : NancyModule
    {
        private readonly ITemplateService templateService;

        public TemplateModule(ITemplateService templateService)
            : base("/_kola/templates/{templatePath*}")
        {
            this.templateService = templateService;

            this.Get["/", AcceptHeaderFilters.NotHtml] = p => this.GetTemplate(p.templatePath);
            this.Get["/_components/{componentPath*}", AcceptHeaderFilters.NotHtml] = p => this.GetComponent(p.templatePath, p.componentPath);
            this.Get["/_amendments", AcceptHeaderFilters.NotHtml] = p => this.GetAmendments(p.templatePath);
            this.Put["/", AcceptHeaderFilters.NotHtml] = p => this.PutTemplate(p.templatePath);
            this.Post["/_amendments/addComponent", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<AddComponentAmendmentResource>(p.templatePath);
            this.Post["/_amendments/moveComponent", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<MoveComponentAmendmentResource>(p.templatePath);
            this.Post["/_amendments/removeComponent", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<RemoveComponentAmendmentResource>(p.templatePath);
            this.Post["/_amendments/duplicateComponent", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<DuplicateComponentAmendmentResource>(p.templatePath);
            this.Post["/_amendments/setProperty", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<SetPropertyAmendmentResource>(p.templatePath);
            this.Post["/_amendments/setComment", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<SetCommentAmendmentResource>(p.templatePath);
            this.Post["/_amendments/apply", AcceptHeaderFilters.NotHtml] = p => this.PostApplyAmendments(p.templatePath);
            this.Post["/_amendments/undo", AcceptHeaderFilters.NotHtml] = p => this.PostUndoAmendment(p.templatePath);
        }

        private dynamic GetTemplate(string rawPath)
        {
            var path = rawPath.ParsePath();

            var result = this.templateService.GetTemplate(path);

            return this.Negotiate.WithModel(result);
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