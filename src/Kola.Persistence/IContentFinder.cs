using System.Collections.Generic;

namespace Kola.Persistence
{
    public interface IContentFinder
    {
        IEnumerable<ContentDirectory> FindContentDirectories(IEnumerable<string> path);
    }
}