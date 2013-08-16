using System;
using Kola.Domain;
using Kola.Persistence;
using Nancy;

namespace Kola.Nancy.Modules
{
    public class TemplatesModule : NancyModule
    {
        private readonly ITemplateRepository templateRepository;

        public TemplatesModule(ITemplateRepository templateRepository)
        {
            this.templateRepository = templateRepository;

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
            var parts = templatePath.Split('/');

            var template = new Template(parts);

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
            throw new NotImplementedException();
        }
    }
}