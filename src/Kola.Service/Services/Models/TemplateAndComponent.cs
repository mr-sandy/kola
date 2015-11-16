namespace Kola.Service.Services.Models
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;

    public class TemplateAndComponent 
    {
        public TemplateAndComponent(Template template, IComponent component, IEnumerable<int> componentPath)
        {
            this.Template = template;
            this.Component = component;
            this.ComponentPath = componentPath;
        }

        public Template Template { get; }

        public IComponent Component { get; }

        public IEnumerable<int> ComponentPath { get; }
    }
}