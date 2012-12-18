using System.Collections.Generic;
using Kola.Model;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy.Extensions
{
    public static class HtmlHelpersExtensions
    {

        public static IHtmlString RenderComponents<T>(this HtmlHelpers<T> helpers, IEnumerable<Component> components)
        {
            return new NonEncodedHtmlString("<h1>Hi</h1>");
        }

        public static IHtmlString RenderComponents2<T>(this HtmlHelpers<T> helpers)
        {
            return new NonEncodedHtmlString("<h1>Success!!!!</h1>");
        }

        //public static IHtmlString RenderComponents<T>(this HtmlHelpers<T> helpers, IEnumerable<Component> components)
        //{
        //    return new ResultBuilder(components.Select(component => Registry.Configuration.Processor.Process(new Request(RequestType.Get, component, new ViewHelper<T>(helpers)))));
        //}
    }
}