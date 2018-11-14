namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    public interface IPathInstanceBuilder
    {
        IEnumerable<string> Build(IEnumerable<string> path, bool preview);
    }
}