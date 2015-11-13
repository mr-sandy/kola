namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    public class RenderingService : IRenderingService
    {
        public IResult<PageInstance> GetPage(IEnumerable<string> path, bool preview)
        {
            throw new System.NotImplementedException();
        }

        public IResult<PageInstance> GetFragment(IEnumerable<string> path, IEnumerable<int> componentPath)
        {
            throw new System.NotImplementedException();
        }
    }
}