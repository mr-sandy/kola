namespace Kola.Nancy.Modules
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;
    using Kola.Extensions;

    using global::Nancy;
    using global::Nancy.ModelBinding;
    using global::Nancy.Responses.Negotiation;

    public class PreviewModule : NancyModule
    {
        private readonly IPageHandler pageHandler;

        public PreviewModule(IPageHandler pageHandler)
        {
            this.pageHandler = pageHandler;
            this.Get["/_kola/preview/(?<rawPath>.*)", AcceptHeaderFilters.Html] = p => this.GetPage(p.rawPath);
            this.Get["/_kola/preview/", AcceptHeaderFilters.Html] = p => this.GetPage(string.Empty);
        }

        // TODO {SC} This should renamed GetContent; the pageHandler should be a content handler, 
        // and should return different types of content: pages; redirects; and 404 content?
        private Negotiator GetPage(string rawPath)
        {
            var path = rawPath.ParsePath();
            var page = this.pageHandler.GetPage(path);

            var query = this.Bind<PreviewQuery>();

            if (!string.IsNullOrEmpty(query.ComponentPath))
            {
                var fragment = this.FindComponent(page, query.ComponentPath.ParseComponentPath());
                return this.Negotiate.WithModel(fragment).WithView("Fragment");
            }

            return this.Negotiate.WithModel(page).WithView("Page");
        }

        private ComponentInstance FindComponent(PageInstance page, IEnumerable<int> componentPath)
        {
            var visitor = new ComponentFindingComponentInstanceVisitor();

            return visitor.Find(page, componentPath);
        }
    }
}