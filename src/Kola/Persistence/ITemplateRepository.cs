namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Templates;

    public interface ITemplateRepository
    {
        void Add(PageTemplate template);
        
        PageTemplate Get(IEnumerable<string> path);
        
        void Update(PageTemplate template);
    }
}