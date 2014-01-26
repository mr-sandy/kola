namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Templates;

    public interface ITemplateRepository
    {
        void Add(Template template);
        
        Template Get(IEnumerable<string> path);
        
        void Update(Template template);
    }
}