using System;
using Kola.Model;

namespace Kola.Processing
{
    internal class ComponentRenderer : IComponentRenderer
    {
        public RenderComponentReponse RenderComponent(IComponent component, RequestContext context)
        {
            var handler = context.HandlerFactory.GetHandler(component);

            return new RenderComponentReponse { Html = handler.HandleRequest(component, context)};
        }
    }
}