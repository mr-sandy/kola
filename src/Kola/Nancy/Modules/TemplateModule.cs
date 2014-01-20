namespace Kola.Nancy.Modules
{
    using System.Linq;

    using Kola.Domain;
    using Kola.Domain.Extensions;
    using Kola.Domain.Templates;
    using Kola.Extensions;
    using Kola.Persistence;
    using Kola.Resources;

    using global::Nancy;
    using global::Nancy.ModelBinding;

    public class TemplateModule : NancyModule
    {
        private readonly ITemplateRepository templateRepository;

        private readonly IComponentSpecificationLibrary componentLibrary;

        public TemplateModule(ITemplateRepository templateRepository, IComponentSpecificationLibrary componentLibrary)
        {
            this.templateRepository = templateRepository;
            this.componentLibrary = componentLibrary;

            this.Get["/_kola/templates/{templatePath*}", AcceptHeaderFilters.NotHtml] = p => this.GetTemplate(p.templatePath);
            this.Get["/_kola/templates/{templatePath*}/_components/{componentPath*}", AcceptHeaderFilters.NotHtml] = p => this.GetComponent(p.templatePath, p.componentPath);
            this.Get["/_kola/templates/{templatePath*}/_amendments", AcceptHeaderFilters.NotHtml] = p => this.GetAmendments(p.templatePath);
            this.Put["/_kola/templates/{templatePath*}", AcceptHeaderFilters.NotHtml] = p => this.PutTemplate(p.templatePath);
            this.Post["/_kola/templates/{templatePath*}/_amendments/addComponent", AcceptHeaderFilters.NotHtml] = p => this.PostAddComponentAmendment(p.templatePath);
            this.Post["/_kola/templates/{templatePath*}/_amendments/moveComponent", AcceptHeaderFilters.NotHtml] = p => this.PostMoveComponentAmendment(p.templatePath);
            this.Post["/_kola/templates/{templatePath*}/_amendments/deleteComponent", AcceptHeaderFilters.NotHtml] = p => this.PostDeleteComponentAmendment(p.templatePath);
            this.Post["/_kola/templates/{templatePath*}/_amendments/apply", AcceptHeaderFilters.NotHtml] = p => this.PostApplyAmendments(p.templatePath);
            this.Post["/_kola/templates/{templatePath*}/_amendments/undo", AcceptHeaderFilters.NotHtml] = p => this.PostUndoAmendments(p.templatePath);
        }

        private dynamic GetTemplate(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            template.ApplyAmendments(this.componentLibrary);

            var resource = template.ToResource();

            return this.Response.AsJson(resource)
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("location", string.Format("/{0}", rawTemplatePath));
        }

        private dynamic GetAmendments(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            var resource = template.Amendments.ToResource(template.Path);

            return this.Response.AsJson(resource)
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("location", string.Format("/{0}", rawTemplatePath));
        }

        private dynamic GetComponent(string rawTemplatePath, string rawComponentPath)
        {
            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            template.ApplyAmendments(this.componentLibrary);

            var componentPath = rawComponentPath.ParseComponentPath();

            var component = template.FindComponent(componentPath);

            var resource = component.ToResource(template.Path, componentPath);

            return this.Response.AsJson(resource)
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("location", string.Format("/{0}", rawTemplatePath));
        }

        private dynamic PutTemplate(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.ParsePath();

            var existingTemplate = this.templateRepository.Get(templatePath);
            if (existingTemplate != null)
            {
                return HttpStatusCode.Conflict;
            }

            var template = new Template(templatePath);

            this.templateRepository.Add(template);

            return this.Response.AsJson(template.ToResource())
                .WithStatusCode(HttpStatusCode.Created)
                .WithHeader("location", string.Format("/{0}", rawTemplatePath));
        }

        private dynamic PostAddComponentAmendment(string rawTemplatePath)
        {
            var amendment = this.Bind<AddComponentAmendmentResource>().ToDomain();

            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            template.AddAmendment(amendment);

            this.templateRepository.Update(template);

            template.ApplyAmendments(this.componentLibrary);

            var resource = amendment.ToResource(template.Path, template.Amendments.Count() - 1, true);

            return this.Response.AsJson(resource).WithStatusCode(HttpStatusCode.Created);
        }

        private dynamic PostMoveComponentAmendment(string rawTemplatePath)
        {
            var amendment = this.Bind<MoveComponentAmendmentResource>().ToDomain();

            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            template.AddAmendment(amendment);

            this.templateRepository.Update(template);

            template.ApplyAmendments(this.componentLibrary);

            var resource = amendment.ToResource(template.Path, template.Amendments.Count() - 1, true);

            return this.Response.AsJson(resource).WithStatusCode(HttpStatusCode.Created);
        }

        private dynamic PostDeleteComponentAmendment(string rawTemplatePath)
        {
            var amendment = this.Bind<DeleteComponentAmendmentResource>().ToDomain();

            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            template.AddAmendment(amendment);

            this.templateRepository.Update(template);

            template.ApplyAmendments(this.componentLibrary);

            var resource = amendment.ToResource(template.Path, template.Amendments.Count() - 1, true);

            return this.Response.AsJson(resource).WithStatusCode(HttpStatusCode.Created);
        }

        private dynamic PostApplyAmendments(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            template.ApplyAmendments(this.componentLibrary, reset: true);

            this.templateRepository.Update(template);

            return this.Response.AsJson(new { jam = "biscuits" })
                .WithStatusCode(HttpStatusCode.Created);
        }

        private dynamic PostUndoAmendments(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            var lastAmendment = template.UndoAmendment();

            this.templateRepository.Update(template);

            template.ApplyAmendments(this.componentLibrary);

            var rootComponentIndex = (lastAmendment == null)
                                         ? Enumerable.Empty<int>()
                                         : lastAmendment.GetRootComponent();

            var snippet = template.FindComponent(rootComponentIndex);

            return this.Response.AsJson(snippet.ToResource(Enumerable.Empty<string>(), rootComponentIndex)).WithStatusCode(HttpStatusCode.Created);
        }
    }
}