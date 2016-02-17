namespace Kola.Service.Services
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    public interface IRenderingService
    {
        IResult<PageInstance> GetPage(IEnumerable<string> path, IEnumerable<KeyValuePair<string, string>> parameters, ClaimsPrincipal user, bool preview);

        IResult<ComponentInstance> GetFragment(IEnumerable<string> path, IEnumerable<KeyValuePair<string, string>> parameters, ClaimsPrincipal user, IEnumerable<int> componentPath);
    }
}
