namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;

    public interface IContentRepository
    {
        void Add(IContent content);

        IContent Get(IEnumerable<string> path);
        
        void Update(IContent content);
    }
}