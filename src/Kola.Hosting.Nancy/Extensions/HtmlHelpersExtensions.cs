using Kola.Model;
using Kola.Processing;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy.Extensions
{
    public static class HtmlHelpersExtensions
    {
        public static IHtmlString RenderPage<T>(this HtmlHelpers<T> helpers, Page page)
        {
            return new RenderPageReponseWrapper(KolaRegistry.KolaEngine.RenderPage(page));
        }
    }

    public class RenderPageReponseWrapper  : IHtmlString
    {
        private readonly RenderPageReponse renderPageReponse;

        public RenderPageReponseWrapper(RenderPageReponse renderPageReponse)
        {
            this.renderPageReponse = renderPageReponse;
        }

        public string ToHtmlString()
        {
            return renderPageReponse.Html;
        }
    }

}