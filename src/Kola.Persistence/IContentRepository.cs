namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;

    public interface IContentRepository
    {
        IEnumerable<FindContentResult> FindContent(IEnumerable<string> path);

        IEnumerable<IEnumerable<string>> GetAllTemplatePaths();

        Template GetTemplate(IEnumerable<string> path);

        void Add(IContent content);

        void Update(IContent content);
    }
}