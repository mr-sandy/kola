namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    public interface IRenderingService
    {
        IResult<PageInstance> GetPage(IEnumerable<string> path, bool preview);

        IResult<PageInstance> GetFragment(IEnumerable<string> path, IEnumerable<int> componentPath);
    }
}
