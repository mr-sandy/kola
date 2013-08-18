using System;
using System.Collections.Generic;
using System.Linq;
using Kola.Domain;
using Kola.Persistence;
using Kola.Resources;
using Nancy;
using Nancy.ModelBinding;

namespace Kola.Nancy.Modules
{
    public class TemplatesModule : NancyModule
    {
        private readonly ITemplateRepository templateRepository;
        private readonly IComponentFactory componentFactory;

        public TemplatesModule(ITemplateRepository templateRepository, IComponentFactory componentFactory)
        {
            this.templateRepository = templateRepository;
            this.componentFactory = componentFactory;

            this.Get["/_kola/templates/{templatePath*}", AcceptHeaderFilters.NotHtml] = p => this.GetTemplate(p.templatePath);
            this.Put["/_kola/templates/{templatePath*}", AcceptHeaderFilters.NotHtml] = p => this.CreateTemplate(p.templatePath);
            this.Get["/_kola/templates/{templatePath*}/_components/{componentPath*}", AcceptHeaderFilters.NotHtml] = p => this.GetComponent(p.templatePath, p.componentPath);
            this.Post["/_kola/templates/{templatePath*}/_components/{componentPath*}", AcceptHeaderFilters.NotHtml] = p => this.AddComponent(p.templatePath, p.componentPath);
        }


        private dynamic GetTemplate(string templatePath)
        {
            throw new NotImplementedException();
            var parts = templatePath.Split('/');
            return "GetTemplate: " + string.Join("-", parts);
        }

        private dynamic CreateTemplate(string templatePath)
        {
            var pathFragments = templatePath.Split('/');

            var template = new Template(pathFragments);

            this.templateRepository.Add(template);

            return this.Response
                .AsJson(template)
                .WithStatusCode(HttpStatusCode.Created)
                .WithHeader("location", string.Format("/{0}", templatePath));
        }

        private dynamic GetComponent(string templatePath, string componentPath)
        {
            throw new NotImplementedException();
        }

        private dynamic AddComponent(string templatePath, string componentPath)
        {
            var componentResource = this.Bind<ComponentResource>();

            var template = this.templateRepository.Get(templatePath.Split('/'));
            if (template == null) return HttpStatusCode.NotFound;

            var parent = template.Components.NavigateTo(componentPath.Split('/').Select(int.Parse)) as ComponentContainer;
            if (parent == null) return HttpStatusCode.NotFound;

            var component = this.componentFactory.Create(componentResource.Name);
            if (component == null) return HttpStatusCode.NotFound;

            parent.AddChild(1, component);

            throw new NotImplementedException();
        }
    }

    public interface IComponentFactory
    {
        IComponent Create(string name);
    }

    internal static class ComponentExtensions
    {
        internal static IComponent NavigateTo(this IEnumerable<IComponent> components, IEnumerable<int> componentPath)
        {
            return null;
        }
    }
}