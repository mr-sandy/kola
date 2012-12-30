using Kola.Processing;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy.Extensions
{
    public class RenderingReponseWrapper  : IHtmlString
    {
        private readonly IRenderingResponse renderPageReponse;

        public RenderingReponseWrapper(IRenderingResponse renderPageReponse)
        {
            this.renderPageReponse = renderPageReponse;
        }

        public string ToHtmlString()
        {
            return renderPageReponse.ToHtml();
        }
    }
}