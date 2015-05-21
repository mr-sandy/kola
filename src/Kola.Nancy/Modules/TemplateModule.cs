namespace Kola.Nancy.Modules
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using global::Nancy;
    using global::Nancy.ModelBinding;

    using Kola.Domain.Composition;
    using Kola.Domain.Extensions;
    using Kola.Nancy.Extensions;
    using Kola.Persistence;
    using Kola.Resources;
    using Kola.Service.DomainBuilding;
    using Kola.Service.ResourceBuilding;
    using Kola.Service.Extensions;

    using HttpStatusCode = global::Nancy.HttpStatusCode;

    // TODO {SC} Refactor bulk of code into a service independent of Nancy (add to the Kola.Services namespace); make this module as lightweight as possible
    public class TemplateModule : NancyModule
    {
        private readonly ITemplateRepository templateRepository;

        private readonly IComponentSpecificationLibrary componentLibrary;

        public TemplateModule(ITemplateRepository templateRepository, IComponentSpecificationLibrary componentLibrary)
            : base("/_kola/templates/{templatePath*}")
        {
            this.templateRepository = templateRepository;
            this.componentLibrary = componentLibrary;

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

        private dynamic GetTemplate(string templatePath)
        {
            var template = this.templateRepository.Get(templatePath.ParsePath());

            if (template == null)
            {
                return HttpStatusCode.NotFound;
            }

            template.ApplyAmendments(this.componentLibrary);

            new ComponentRefreshingVisitor(this.componentLibrary).Refresh(template);

            var resource = new TemplateResourceBuilder().Build(template);

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json");
        }

        private dynamic GetAmendments(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null)
            {
                return HttpStatusCode.NotFound;
            }

            var resource = new AmendmentResourceBuilder().Build(template.Amendments, template.Path);

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json")
                .WithHeader("location", string.Format("/{0}", rawTemplatePath));
        }

        private dynamic GetComponent(string rawTemplatePath, string rawComponentPath)
        {
            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null)
            {
                return HttpStatusCode.NotFound;
            }

            template.ApplyAmendments(this.componentLibrary);

            var componentPath = rawComponentPath.ParseComponentPath();

            var component = template.FindComponent(componentPath);

            // Add all properties for this component type (not just those with values set)
            component.Accept(new ComponentRefreshingVisitor(this.componentLibrary));

            var resource = new ComponentResourceBuilder().Build(component, componentPath, template.Path);

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json")
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

            var resource = new TemplateResourceBuilder().Build(template);

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json")
                .WithStatusCode(HttpStatusCode.Created)
                .WithHeader("location", string.Format("/{0}", rawTemplatePath));
        }

        private dynamic PostAmendment<T>(string rawTemplatePath)
            where T : AmendmentResource
        {
            var amendment = new AmendmentDomainBuilder().Build(this.Bind<T>());

            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null)
            {
                return HttpStatusCode.NotFound;
            }

            template.AddAmendment(amendment);

            this.templateRepository.Update(template);

            template.ApplyAmendments(this.componentLibrary);

            var resource = new AmendmentResourceBuilder().Build(amendment, template.Path, template.Amendments.Count() - 1);

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json")
                .WithStatusCode(HttpStatusCode.Created);
        }

        private dynamic PostApplyAmendments(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null)
            {
                return HttpStatusCode.NotFound;
            }

            template.ApplyAmendments(this.componentLibrary, reset: true);

            this.templateRepository.Update(template);

            return this.Negotiate
                .WithModel(new { jam = "biscuits" })
                .WithAllowedMediaRange("application/json")
                .WithStatusCode(HttpStatusCode.Created);
        }

        private dynamic PostUndoAmendment(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.ParsePath();
            var template = this.templateRepository.Get(templatePath);

            if (template == null)
            {
                return HttpStatusCode.NotFound;
            }

            var amendment = template.UndoAmendment();

            this.templateRepository.Update(template);

            var resource = new
            {
                Links = amendment.SubjectPaths.Select(subjectPath => new LinkResource { Rel = "subject", Href = string.Join("/", subjectPath) }).ToArray()
            };

            return this.Negotiate
                .WithModel(resource)
                .WithAllowedMediaRange("application/json")
                .WithStatusCode(HttpStatusCode.OK);
        }
    }
}