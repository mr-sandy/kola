using System;
using System.Collections.Generic;
using System.Linq;
using Kola.Domain;
using Kola.Nancy.Extensions;
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


        private dynamic GetTemplate(string rawTemplatePath)
        {
            throw new NotImplementedException();
            //var templatePath = rawTemplatePath.Split('/');
            //return "GetTemplate: " + string.Join("-", parts);
        }

        private dynamic CreateTemplate(string rawTemplatePath)
        {
            var templatePath = rawTemplatePath.Split('/');

            var template = new Template(templatePath);

            this.templateRepository.Add(template);

            return this.Response
                .AsJson(template)
                .WithStatusCode(HttpStatusCode.Created)
                .WithHeader("location", string.Format("/{0}", rawTemplatePath));
        }

        private dynamic GetComponent(string rawTemplatePath, string rawComponentPath)
        {
            throw new NotImplementedException();
        }

        private dynamic AddComponent(string rawTemplatePath, string rawComponentPath)
        {
            var componentResource = this.Bind<ComponentResource>();

            var template = this.templateRepository.Get(rawTemplatePath.Split('/'));
            if (template == null) return HttpStatusCode.NotFound;

            var componentPath = rawComponentPath.Split('/').Select(int.Parse);
            if (componentPath.Count() == 0) return HttpStatusCode.NotFound;

            var parent = (componentPath.Count() == 1)
                ? template
                : template.Components.NavigateTo(componentPath.TakeAllButLast()) as ComponentContainer;
            if (parent == null) return HttpStatusCode.NotFound;

            var component = this.componentFactory.Create(componentResource.Name);
            if (component == null) return HttpStatusCode.BadRequest;

            if (!parent.AddChild(componentPath.Last(), component)) { return HttpStatusCode.BadRequest; }

            this.templateRepository.Update(template);
            return HttpStatusCode.Created;
        }
    }

    public interface IComponentFactory
    {
        IComponent Create(string name);
    }

    public class ComponentFactory : IComponentFactory
    {
        public IComponent Create(string name)
        {
            throw new NotImplementedException();
        }
    }

    internal static class ComponentExtensions
    {
        internal static IComponent NavigateTo(this IEnumerable<IComponent> components, IEnumerable<int> componentPath)
        {
            return null;
        }
    }
}