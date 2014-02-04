namespace Kola.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Domain.Instances;

    public interface IPageHandler
    {
        PageInstance GetPage(IEnumerable<string> path);
    }
}