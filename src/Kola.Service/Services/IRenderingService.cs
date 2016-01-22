namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;
    using Kola.Service.Services.Results;

    public interface IRenderingService
    {
        IResult<PageInstance> GetPage(IEnumerable<string> path, IEnumerable<KeyValuePair<string, string>> parameters, IUser user, bool preview);

        IResult<ComponentInstance> GetFragment(IEnumerable<string> path, IEnumerable<KeyValuePair<string, string>> parameters, IUser user, IEnumerable<int> componentPath);
    }
}
