namespace Kola.Nancy
{
    using Kola.Processing;

    using global::Nancy.ViewEngines.Razor;

    internal class HtmlReponseWrapper : IHtmlString
    {
        private readonly IResult result;
        private readonly IViewHelper viewHelper;

        public HtmlReponseWrapper(IResult result, IViewHelper viewHelper)
        {
            this.result = result;
            this.viewHelper = viewHelper;
        }

        public string ToHtmlString()
        {
            return this.result.ToHtml(this.viewHelper);
        }
    }
}