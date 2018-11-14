namespace Kola.Persistence
{
    using System.Collections.Generic;

    public interface IContentLister
    {
        IEnumerable<string> FindAllPaths();
    }
}