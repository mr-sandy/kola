namespace Kola.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Domain.Instances;

    public interface IPageHandler
    {
        IPage GetPage(IEnumerable<string> path);
    }
}