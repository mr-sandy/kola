using System.Collections.Generic;
using Kola.Model;
using Kola.Processing;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy.Extensions
{
    public static class HtmlHelpersExtensions
    {
        public static IHtmlString RenderComponents<T>(this HtmlHelpers<T> helpers, IEnumerable<Component> components)
        {
            return new KolaResultHtmlStringWrapper(KolaRegistry.KolaEngine.Render(components));
        }
    }

    public class KolaResultHtmlStringWrapper : IHtmlString
    {
        private readonly KolaResult kolaResult;

        public KolaResultHtmlStringWrapper(KolaResult kolaResult)
        {
            this.kolaResult = kolaResult;
        }

        public string ToHtmlString()
        {
            return kolaResult.Html;
        }
    }

}