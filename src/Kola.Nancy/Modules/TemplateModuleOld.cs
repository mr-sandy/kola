//namespace Kola.Nancy.Modules
//{
//    using System.Linq;

//    using global::Nancy;
//    using global::Nancy.ModelBinding;

//    using Kola.Domain.Composition;
//    using Kola.Domain.Extensions;
//    using Kola.Nancy.Extensions;
//    using Kola.Persistence;
//    using Kola.Resources;
//    using Kola.Service.DomainBuilding;
//    using Kola.Service.ResourceBuilding;

//    // TODO {SC} Refactor bulk of code into a service independent of Nancy (add to the Kola.Services namespace); make this module as lightweight as possible
//    public class TemplateModule : NancyModule
//    {
//        private readonly IContentRepository contentRepository;

//        private readonly IComponentSpecificationLibrary componentLibrary;

//        public TemplateModule(IContentRepository contentRepository, IComponentSpecificationLibrary componentLibrary)
//            : base("/_kola/templates/{templatePath*}")
//        {
//            this.contentRepository = contentRepository;
//            this.componentLibrary = componentLibrary;

//            this.Get["/", AcceptHeaderFilters.NotHtml] = p => this.GetTemplate(p.templatePath);
//            this.Get["/_components/{componentPath*}", AcceptHeaderFilters.NotHtml] = p => this.GetComponent(p.templatePath, p.componentPath);
//            this.Get["/_amendments", AcceptHeaderFilters.NotHtml] = p => this.GetAmendments(p.templatePath);
//            this.Put["/", AcceptHeaderFilters.NotHtml] = p => this.PutTemplate(p.templatePath);
//            this.Post["/_amendments/addComponent", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<AddComponentAmendmentResource>(p.templatePath);
//            this.Post["/_amendments/moveComponent", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<MoveComponentAmendmentResource>(p.templatePath);
//            this.Post["/_amendments/removeComponent", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<RemoveComponentAmendmentResource>(p.templatePath);
//            this.Post["/_amendments/duplicateComponent", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<DuplicateComponentAmendmentResource>(p.templatePath);
//            this.Post["/_amendments/setProperty", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<SetPropertyAmendmentResource>(p.templatePath);
//            this.Post["/_amendments/setComment", AcceptHeaderFilters.NotHtml] = p => this.PostAmendment<SetCommentAmendmentResource>(p.templatePath);
//            this.Post["/_amendments/apply", AcceptHeaderFilters.NotHtml] = p => this.PostApplyAmendments(p.templatePath);
//            this.Post["/_amendments/undo", AcceptHeaderFilters.NotHtml] = p => this.PostUndoAmendment(p.templatePath);
//        }

//        private dynamic GetTemplate(string templatePath)
//        {
//            var template = this.contentRepository.Get(templatePath.ParsePath()) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            template.ApplyAmendments(this.componentLibrary);

//            new ComponentRefreshingVisitor(this.componentLibrary).Refresh(template);

//            var resource = new TemplateResourceBuilder().Build(template);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json");
//        }

//        private dynamic GetAmendments(string rawTemplatePath)
//        {
//            var templatePath = rawTemplatePath.ParsePath();
//            var template = this.contentRepository.Get(templatePath) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            var resource = new AmendmentResourceBuilder().Build(template.Amendments, template.Path);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json")
//                .WithHeader("location", $"/{rawTemplatePath}");
//        }

//        private dynamic GetComponent(string rawTemplatePath, string rawComponentPath)
//        {
//            var templatePath = rawTemplatePath.ParsePath();
//            var template = this.contentRepository.Get(templatePath) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            template.ApplyAmendments(this.componentLibrary);

//            var componentPath = rawComponentPath.ParseComponentPath().ToArray();

//            var component = template.FindComponent(componentPath);

//            // Add all properties for this component type (not just those with values set)
//            component.Accept(new ComponentRefreshingVisitor(this.componentLibrary));

//            var resource = new ComponentResourceBuilder().Build(component, componentPath, template.Path);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json")
//                .WithHeader("location", $"/{rawTemplatePath}");
//        }


//        private dynamic PutTemplate(string rawTemplatePath)
//        {
//            var templatePath = rawTemplatePath.ParsePath().ToArray();

//            var existingTemplate = this.contentRepository.Get(templatePath) as Template;
//            if (existingTemplate != null)
//            {
//                return HttpStatusCode.Conflict;
//            }

//            var template = new Template(templatePath);

//            this.contentRepository.Add(template);

//            var resource = new TemplateResourceBuilder().Build(template);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json")
//                .WithStatusCode(HttpStatusCode.Created)
//                .WithHeader("location", $"/{rawTemplatePath}");
//        }

//        private dynamic PostAmendment<T>(string rawTemplatePath)
//            where T : AmendmentResource
//        {
//            var amendment = new AmendmentDomainBuilder().Build(this.Bind<T>());

//            var templatePath = rawTemplatePath.ParsePath();
//            var template = this.contentRepository.Get(templatePath) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            template.AddAmendment(amendment);

//            this.contentRepository.Update(template);

//            template.ApplyAmendments(this.componentLibrary);

//            var resource = new AmendmentResourceBuilder().Build(amendment, template.Path, template.Amendments.Count() - 1);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json")
//                .WithStatusCode(HttpStatusCode.Created);
//        }

//        private dynamic PostApplyAmendments(string rawTemplatePath)
//        {
//            var templatePath = rawTemplatePath.ParsePath();
//            var template = this.contentRepository.Get(templatePath) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            template.ApplyAmendments(this.componentLibrary, reset: true);

//            this.contentRepository.Update(template);

//            return this.Negotiate
//                .WithModel(new { jam = "biscuits" })
//                .WithAllowedMediaRange("application/json")
//                .WithStatusCode(HttpStatusCode.Created);
//        }

//        private dynamic PostUndoAmendment(string rawTemplatePath)
//        {
//            var templatePath = rawTemplatePath.ParsePath();
//            var template = this.contentRepository.Get(templatePath) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            var amendment = template.UndoAmendment();

//            this.contentRepository.Update(template);

//            var resource = new
//            {
//                Links = amendment.AffectedPaths.Select(affectedPath => new LinkResource { Rel = "affected", Href = string.Join("/", affectedPath) })
//                        .Union(new[] { new LinkResource { Rel = "subject", Href = string.Join("/", amendment.AffectedPaths.First()) } })
//                        .ToArray()
//            };

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json")
//                .WithStatusCode(HttpStatusCode.OK);
//        }
//    }
//}