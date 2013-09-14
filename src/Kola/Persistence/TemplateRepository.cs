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

            var component1 = new Component("copmonent1");
            template.AddComponent(component1);

            var component11 = new Component("copmonent1.1");
            component1.AddComponent(component11);

            var component2 = new Component("copmonent2");
            template.AddComponent(component2);

            return template;
        }

        public void Update(Template template)
        {
        }
    }
}