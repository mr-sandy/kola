using System;
using Kola.Configuration;
using Kola.Model;

namespace Kola.Processing
{
    internal class DefaultHandler : IHandler
    {
        public IRenderingResponse HandleRequest(IComponent component, RequestContext context)
        {
            return new RenderingResponse(viewHelper => viewHelper.RenderPartial(component.Name, component));
        }
    }
}