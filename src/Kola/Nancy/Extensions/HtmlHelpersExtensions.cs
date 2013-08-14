using System.Collections.Generic;
using Kola.Model;
using Kola.Processing;
using Nancy.ViewEngines.Razor;

namespace Kola.Nancy.Extensions
{
    public static class HtmlHelpersExtensions
    {
        public static IHtmlString RenderPage<T>(this HtmlHelpers<T> helpers, Page page)
        {
            return new HtmlReponseWrapper(KolaRegistry.KolaEngine.RenderPage(page), new NancyRazorViewHelper<T>(helpers));
        }
        
        public static IHtmlString RenderComponents<T>(this HtmlHelpers<T> helpers, IEnumerable<IComponent> components)
        {
            return new HtmlReponseWrapper(KolaRegistry.KolaEngine.RenderComponents(components), new NancyRazorViewHelper<T>(helpers));
        }
    }

    public static class NancyRazorViewBaseExtensions
    {
        public static string UriFor<TEntity>(this NancyRazorViewBase<TEntity> helper, string path)
        {
            var root = "venus";
            return root.TrimEnd('/') + '/' + path.TrimStart('/');
        }
    }
}