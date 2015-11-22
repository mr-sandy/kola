namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;

    public interface IContentRepository
    {
        void Add(IContent content);

        IEnumerable<FindContentResult> FindContent(IEnumerable<string> path);

        Template GetTemplate(IEnumerable<string> path);

        void Update(IContent content);
    }
}