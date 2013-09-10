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
            this.Put["/_kola/templates/{templatePath*}", AcceptHeaderFilters.NotHtml] = p => this.CreateTemplate(p.templatePath);
            this.Post["/_kola/templates/{templatePath*}/_components/{componentPath*}", AcceptHeaderFilters.NotHtml] = p => this.AddComponent(p.templatePath, p.componentPath);
        }

        private dynamic GetTemplate(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.Split('/');
            var template = this.templateRepository.Get(templatePath);

            if (template == null) return HttpStatusCode.NotFound;

            return this.Response.AsJson(template.ToResource())
                .WithStatusCode(HttpStatusCode.Created)
                .WithHeader("location", string.Format("/{0}", rawTemplatePath));
        }

        private dynamic CreateTemplate(string rawTemplatePath)
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

        private dynamic AddComponent(string rawTemplatePath, string rawComponentPath)
        {
            var componentResource = this.Bind<ComponentResource>();

            var template = this.templateRepository.Get(rawTemplatePath.Split('/'));
            if (template == null)
            {
                return HttpStatusCode.NotFound;
            }

            var componentPath = rawComponentPath.Split('/').Select(int.Parse);
            if (componentPath.Count() == 0)
            {
                return HttpStatusCode.NotFound;
            }

            var parent = (componentPath.Count() == 1)
                             ? template
                             : template.Components.NavigateTo(componentPath.TakeAllButLast()) as ComponentContainer;
            if (parent == null)
            {
                return HttpStatusCode.NotFound;
            }

            var component = this.componentFactory.Create(componentResource.Type);
            if (component == null)
            {
                return HttpStatusCode.BadRequest;
            }

            if (!parent.AddChild(componentPath.Last(), component))
            {
                return HttpStatusCode.BadRequest;
            }

            this.templateRepository.Update(template);
            return HttpStatusCode.Created;
        }
    }
}