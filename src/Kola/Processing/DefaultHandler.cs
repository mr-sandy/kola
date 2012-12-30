using System;
using Kola.Configuration;
using Kola.Model;

namespace Kola.Processing
{
    internal class DefaultHandler : IHandler
    {
        public IRenderingResponse HandleRequest(IComponent component, RequestContext context)
        {
            return new RenderingResponse(() => context.ViewHelper.RenderPartial(component.Name, component));
        }
    }
}