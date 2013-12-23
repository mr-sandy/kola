using Kola.Processing;
using Nancy.ViewEngines.Razor;

namespace Kola.Nancy
{
    using System;

    public class NancyRazorViewHelper<T> : IViewHelper
    {
        private readonly HtmlHelpers<T> htmlHelpers;

        public NancyRazorViewHelper(HtmlHelpers<T> htmlHelpers)
        {
            this.htmlHelpers = htmlHelpers;
        }

        public string RenderPartial<TModel>(string viewName, TModel model)
        {
            return this.htmlHelpers.Partial(viewName, model).ToHtmlString();
        }

        public string RenderPartial(string viewName, IComponent component)
        {
            throw new NotImplementedException();
        }
    }
}