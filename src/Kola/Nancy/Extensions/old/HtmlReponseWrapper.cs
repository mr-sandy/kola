namespace Kola.Nancy.Extensions
{
    using Kola.Processing;

    using global::Nancy.ViewEngines.Razor;

    internal class HtmlReponseWrapper : IHtmlString
    {
        private readonly IResult renderPageReponse;
        private readonly IViewHelper viewHelper;

        public HtmlReponseWrapper(IResult renderPageReponse, IViewHelper viewHelper)
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