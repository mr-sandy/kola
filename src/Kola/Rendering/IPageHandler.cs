namespace Kola.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain;

    public interface IPageHandler
    {
        IPage GetPage(IEnumerable<string> path);
    }
}