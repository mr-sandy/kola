
using System.Collections.Generic;
using Kola.Domain;

namespace Kola.Persistence
{
    public interface ITemplateRepository
    {
        void Add(Template template);
        Template Get(IEnumerable<string> path);
        void Update(Template template);
    }
}