using System.Linq;
using Kola.Domain;
using Kola.Processing.Dependencies;

namespace Kola.Processing
{
    internal class DefaultHandler : IHandler
    {
        public IRenderingResponse HandleRequest(IComponent component, RequestContext context)
        {
            return new RenderingResponse(viewHelper => viewHelper.RenderPartial(component.Name, component), Enumerable.Empty<IDependency>());
        }
    }
}