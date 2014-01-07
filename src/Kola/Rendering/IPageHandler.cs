namespace Kola.Rendering
{
    using System.Collections.Generic;

    public interface IPageHandler
    {
        IPage GetPage(IEnumerable<string> path);
    }
}