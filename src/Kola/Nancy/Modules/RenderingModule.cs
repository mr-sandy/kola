namespace Kola.Nancy.Modules
{
    using Kola.Domain.Rendering;
    using Kola.Extensions;

    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    public class RenderingModule : NancyModule
    {
        private readonly IPageHandler pageHandler;

        public RenderingModule(IPageHandler pageHandler)
        {
            this.pageHandler = pageHandler;
            this.Get["(?<rawPath>.*)", AcceptHeaderFilters.Html] = p => this.GetPage(p.rawPath);
            this.Get["/", AcceptHeaderFilters.Html] = p => this.GetPage(string.Empty);
        }

        private Negotiator GetPage(string rawPath)
        {
            var path = rawPath.ParsePath();
            var page = this.pageHandler.GetPage(path);

            return this.Negotiate
                .WithStatusCode(HttpStatusCode.OK)
                .WithMediaRangeModel("text/html", page)
                .WithView("Page");
        }
    }
}