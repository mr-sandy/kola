namespace Kola.Nancy.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;

    using global::Nancy.ViewEngines.Razor;

    public static class HtmlHelpersExtensions
    {
        public static IHtmlString RenderPage<T>(this HtmlHelpers<T> helpers, PageInstance page)
        {
            var engine = NancyKolaConfigurationRegistry.Instance.KolaEngine;
            return new ResultWrapper(engine.Render(page), new NancyRazorViewHelper<T>(helpers));
        }

        public static IHtmlString RenderComponents<T>(this HtmlHelpers<T> helpers, IEnumerable<IComponentInstance> components)
        {
            var engine = NancyKolaConfigurationRegistry.Instance.KolaEngine;
            return new ResultWrapper(engine.Render(components), new NancyRazorViewHelper<T>(helpers));
        }
    }
}