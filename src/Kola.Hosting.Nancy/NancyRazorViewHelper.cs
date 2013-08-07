using Kola.Processing;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy
{
    public class NancyRazorViewHelper<T> : IViewHelper
    {
        private readonly HtmlHelpers<T> htmlHelpers;

        public NancyRazorViewHelper(HtmlHelpers<T> htmlHelpers)
        {
            this.htmlHelpers = htmlHelpers;
        }

        public string RenderPartial<TModel>(string viewName, TModel model)
        {
            var htmlString = this.htmlHelpers.Partial(viewName, model);
            return htmlString.ToHtmlString();
            //return this.htmlHelpers.Partial(viewName, model).ToHtmlString();
        }
    }
}