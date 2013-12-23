namespace Kola.Nancy.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Nancy;
    using Kola.Processing;

    using global::Nancy.ViewEngines.Razor;

    using Kola.Processing.old;

    public static class HtmlHelpersExtensions
    {
        //public static IHtmlString RenderPage<T>(this HtmlHelpers<T> helpers, Page page)
        //{
        //    return new HtmlReponseWrapper(KolaRegistry.KolaEngine.RenderPage(page), new NancyRazorViewHelper<T>(helpers));
        //}
        
        //public static IHtmlString RenderComponents<T>(this HtmlHelpers<T> helpers, IEnumerable<Component> components)
        //{
        //    return new HtmlReponseWrapper(KolaRegistry.KolaEngine.RenderComponents(components), new NancyRazorViewHelper<T>(helpers));
        //}
    }
}