namespace Kola.Nancy.Modules
{
    using System.Linq;

    using Kola.Domain;
    using Kola.Nancy.Extensions;
    using Kola.Persistence;
    using Kola.Resources;

    using global::Nancy;
    using global::Nancy.ModelBinding;

    public class TemplateModule : NancyModule
    {
        private readonly ITemplateRepository templateRepository;

        private readonly IComponentFactory componentFactory;

        public TemplateModule(ITemplateRepository templateRepository, IComponentFactory componentFactory)
        {
            this.templateRepository = templateRepository;
            this.componentFactory = componentFactory;

            this.Get["/_kola/templates/{templatePath*}", AcceptHeaderFilters.NotHtml] = p => this.GetTemplate(p.templatePath);
            this.Put["/_kola/templates/{templatePath*}", AcceptHeaderFilters.NotHtml] = p => this.PutTemplate(p.templatePath);
            this.Post["/_kola/templates/{templatePath*}/_amendments/addComponent", AcceptHeaderFilters.NotHtml] = p => this.PostAddComponentAmendment(p.templatePath);
            this.Post["/_kola/templates/{templatePath*}/_amendments/moveComponent", AcceptHeaderFilters.NotHtml] = p => this.PostMoveComponentAmendment(p.templatePath);
        }

        private dynamic GetTemplate(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.Split('/');
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            var resource = template.ToResource();
            return this.Response.AsJson(resource)
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("location", string.Format("/{0}", rawTemplatePath));
        }

        private dynamic PutTemplate(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.Split('/');

            var existingTemplate = this.templateRepository.Get(templatePath);
            if (existingTemplate != null)
            {
                return HttpStatusCode.BadRequest;
            }

            var template = new Template(templatePath);

            this.templateRepository.Add(template);

            return this.Response.AsJson(template.ToResource())
                .WithStatusCode(HttpStatusCode.Created)
                .WithHeader("location", string.Format("/{0}", rawTemplatePath));
        }

        private dynamic PostAmendment<T>(string rawTemplatePath, Amendment amendment)
        {
            var templatePath = rawTemplatePath.Split('/');
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            template.AddAmendment(amendment);

            this.templateRepository.Update(template);

            return HttpStatusCode.Created;
        }

        private dynamic PostAddComponentAmendment(string rawTemplatePath)
        {
            return this.PostAmendment<AddComponentAmendmentResource>(rawTemplatePath, this.Bind<AddComponentAmendmentResource>().ToDomain());
        }

        private dynamic PostMoveComponentAmendment(string rawTemplatePath)
        {
            return this.PostAmendment<AddComponentAmendmentResource>(rawTemplatePath, this.Bind<AddComponentAmendmentResource>().ToDomain());
        }
    }
}