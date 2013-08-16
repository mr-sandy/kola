using System;
using Kola.Persistence;
using Nancy;

namespace Kola.Nancy.Modules
{
    internal class TemplatesModule : NancyModule
    {
        private readonly ITemplateRepository templateRepository;

        public TemplatesModule(ITemplateRepository templateRepository)
        {
            this.templateRepository = templateRepository;

            this.Get["/_kola/templates/{templatePath*}", AcceptHeaderFilters.NotHtml] = p => this.GetTemplate(p.templatePath);
            this.Put["/_kola/templates/{templatePath*}", AcceptHeaderFilters.NotHtml] = p => this.CreateTemplate(p.templatePath);
            this.Get["/_kola/templates/{templatePath*}/_components/{componentPath*}", AcceptHeaderFilters.NotHtml] = p => this.GetComponent(p.templatePath, p.componentPath);
            this.Post["/_kola/templates/{templatePath*}/_components/{componentPath*}", AcceptHeaderFilters.NotHtml] = p => this.AddComponents(p.templatePath, p.componentPath);
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

            //TODO {SC} Start from here
            throw new NotImplementedException();
        }

        private dynamic GetComponent(string templatePath, string componentPath)
        {
            throw new NotImplementedException();
        }

        private dynamic AddComponents(string templatePath, string componentPath)
        {
            throw new NotImplementedException();
        }
    }
}