namespace Kola.Nancy.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Rendering;

    using global::Nancy.ViewEngines.Razor;

    public static class HtmlHelpersExtensions
    {
        public static IHtmlString RenderPage<T>(this HtmlHelpers<T> helpers, IPage page)
        {
            var engine = NancyKolaRegistry.KolaConfiguration.KolaEngine;
            return new ResultWrapper(engine.Render(page), new NancyRazorViewHelper<T>(helpers));
        }

        public static IHtmlString RenderComponents<T>(this HtmlHelpers<T> helpers, IEnumerable<IComponent> components)
        {
            var engine = NancyKolaRegistry.KolaConfiguration.KolaEngine;
            return new ResultWrapper(engine.Render(components), new NancyRazorViewHelper<T>(helpers));
        }
    }
}