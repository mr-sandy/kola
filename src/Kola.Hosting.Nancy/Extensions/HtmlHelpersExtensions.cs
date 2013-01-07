using System.Collections.Generic;
using Kola.Model;
using Kola.Processing;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy.Extensions
{
    public static class HtmlHelpersExtensions
    {
        public static IHtmlString RenderPage<T>(this HtmlHelpers<T> helpers, Page page)
        {
            return new RenderingReponseWrapper(KolaRegistry.KolaEngine.RenderPage(page), new NancyRazorViewHelper<T>(helpers));
        }

        public static IHtmlString RenderComponents<T>(this HtmlHelpers<T> helpers, IEnumerable<IComponent> components)
        {
            return new RenderingReponseWrapper(KolaRegistry.KolaEngine.RenderComponents(components), new NancyRazorViewHelper<T>(helpers));
        }

        public static IHtmlString RenderBadger(this KolaHtmlHelper helper, IComponent component)
        {
            return new TempHtmlString();
        }
    }

    public class TempHtmlString : IHtmlString
    {
        public string ToHtmlString()
        {
            return "From Kola extension method";
        }
    }
}