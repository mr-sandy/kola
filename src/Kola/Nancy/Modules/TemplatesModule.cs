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
        private readonly IComponentSpecificationLibrary componentSpecificationLibrary;

        public TemplatesModule(ITemplateRepository templateRepository, IComponentSpecificationLibrary componentSpecificationLibrary)
        {
            this.templateRepository = templateRepository;
            this.componentSpecificationLibrary = componentSpecificationLibrary;

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

            var templatePathFragments = templatePath.Split('/');
            var template = this.templateRepository.Get(templatePathFragments);

            if (template == null) return HttpStatusCode.NotFound;

            var componentPathFragments = componentPath.Split('/').Select(int.Parse);
            var parent = template.Components.NavigateTo(componentPathFragments);



            var componentSpecification = this.componentSpecificationLibrary.LookUp(componentResource.Name);
            throw new NotImplementedException();
        }
    }

    public interface IComponentSpecificationLibrary
    {
        IComponentSpecification LookUp(string name);
    }

    internal static class ComponentExtensions
    {
        internal static IComponent NavigateTo(this IEnumerable<IComponent> components, IEnumerable<int> componentPath)
        {
            return null;
        }
    }
}