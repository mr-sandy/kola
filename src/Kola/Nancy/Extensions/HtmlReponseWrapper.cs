namespace Kola.Nancy.Extensions
{
    using Kola.Processing;

    using global::Nancy.ViewEngines.Razor;

    internal class HtmlReponseWrapper : IHtmlString
    {
        private readonly IHtmlResponse renderPageReponse;
        private readonly IViewHelper viewHelper;

        public HtmlReponseWrapper(IHtmlResponse renderPageReponse, IViewHelper viewHelper)
        {
            this.renderPageReponse = renderPageReponse;
            this.viewHelper = viewHelper;
        }

        public string ToHtmlString()
        {
            return this.renderPageReponse.ToHtml(this.viewHelper);
        }
    }
}