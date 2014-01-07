namespace Kola.Nancy
{
    using Kola.Rendering;

    using global::Nancy.ViewEngines.Razor;

    internal class ResultWrapper : IHtmlString
    {
        private readonly IResult result;
        private readonly IViewHelper viewHelper;

        public ResultWrapper(IResult result, IViewHelper viewHelper)
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