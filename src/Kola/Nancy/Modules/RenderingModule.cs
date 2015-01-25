namespace Kola.Nancy.Modules
{
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;
    using Kola.Extensions;

    using global::Nancy;
    using global::Nancy.ModelBinding;
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

        // TODO {SC} This should renamed GetContent; the pageHandler should be a content handler, 
        // and should return different types of content: pages; redirects; and 404 content?
        private Negotiator GetPage(string rawPath)
        {
            var path = rawPath.ParsePath();
            var query = this.Bind<RenderQuery>();
            var page = this.pageHandler.GetPage(path, query.IsPreview);

            if (!string.IsNullOrEmpty(query.ComponentPath))
            {
                var visitor = new ComponentFindingComponentInstanceVisitor();
                var fragment = visitor.Find(page, query.ComponentPath.ParseComponentPath());

                return this
                    .Negotiate
                    .WithModel(fragment)
                    .WithView("Fragment");
            }

            return this.Negotiate
                .WithModel(page)
                .WithView("Page");
        }
    }
}