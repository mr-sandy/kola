using Kola.Processing;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy.Extensions
{
    public class RenderingReponseWrapper  : IHtmlString
    {
        private readonly IRenderingResponse renderPageReponse;
        private readonly IViewHelper viewHelper;

        public RenderingReponseWrapper(IRenderingResponse renderPageReponse, IViewHelper viewHelper)
        {
            this.renderPageReponse = renderPageReponse;
            this.viewHelper = viewHelper;
        }

        public string ToHtmlString()
        {
            return renderPageReponse.ToHtml(this.viewHelper);
        }
    }
}