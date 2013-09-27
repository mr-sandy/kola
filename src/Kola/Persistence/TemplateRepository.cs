namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain;

    internal class TemplateRepository : ITemplateRepository
    {
        public void Add(Template template)
        {
        }

        public Template Get(IEnumerable<string> path)
        {
            var template = new Template(path);

            var component0 = new Component("component 0");
            template.AddComponent(component0);

            var component00 = new Component("component 0.0");
            component0.AddComponent(component00);

            var component000 = new Component("component 0.0.0");
            component00.AddComponent(component000);

            var component1 = new Component("component 1");
            template.AddComponent(component1);

            var component10 = new Component("component 1.0");
            component1.AddComponent(component10);

            var component2 = new Component("component 2");
            template.AddComponent(component2);

            var component20 = new Component("component 2.0");
            component2.AddComponent(component20);

            return template;
        }

        public void Update(Template template)
        {
        }
    }
}