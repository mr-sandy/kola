namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain;

    internal class TemplateRepository : ITemplateRepository
    {
        public void Add(Template template)
        {
        }

        public Template Get(IEnumerable<string> path)
        {
            return new Template(path);
        }

        public void Update(Template template)
        {
        }
    }
}