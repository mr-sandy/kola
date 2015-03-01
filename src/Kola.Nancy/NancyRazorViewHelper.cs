namespace Kola.Nancy
{
    using Kola.Domain.Rendering;

    using global::Nancy.ViewEngines.Razor;

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
    }
}