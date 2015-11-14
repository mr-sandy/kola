namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;
    using Kola.Service.Services.Results;

    public interface IRenderingService
    {
        IResult<PageInstance> GetPage(IEnumerable<string> path, IRenderingInstructions renderingInstructions);

        IResult<ComponentInstance> GetFragment(IEnumerable<string> path, IRenderingInstructions renderingInstructions, IEnumerable<int> componentPath);
    }
}
