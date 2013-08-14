using Kola.Processing;
using Nancy.ViewEngines.Razor;

namespace Kola.Nancy.Extensions
{
    public class HtmlReponseWrapper : IHtmlString
    {
        private readonly IHtmlResponse renderPageReponse;
        private readonly IViewHelper viewHelper;

        public HtmlReponseWrapper(IHtmlResponse renderPageReponse, IViewHelper viewHelper)
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