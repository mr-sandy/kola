
using System;
using Kola.Model;
using Kola.Processing;

namespace Kola.Configuration
{
    public interface IHandler
    {
        string HandleRequest(IComponent component, RequestContext context);
    }

    public interface IHandlerRequestResponse
    {
        string ToHtml();
    }
}