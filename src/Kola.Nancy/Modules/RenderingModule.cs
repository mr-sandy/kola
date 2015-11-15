namespace Kola.Nancy.Modules
{
    using System.Collections.Generic;

    using global::Nancy;
    using global::Nancy.ModelBinding;
    using global::Nancy.Responses.Negotiation;

    using Kola.Nancy.Extensions;
    using Kola.Service.Services;

    public class RenderingModule : NancyModule
    {
        private readonly IRenderingService renderingService;

        public RenderingModule(IRenderingService renderingService)
        {
            this.renderingService = renderingService;
            this.Get["/"] = this.GetResponse;
            this.Get["/(.*)"] = this.GetResponse;
            this.Get["/{path*}"] = this.GetResponse;
        }

        private Negotiator GetResponse(dynamic _)
        {
            var query = this.Bind<RenderQuery>();
            var path = this.Request.Path.ParsePath();

            return string.IsNullOrEmpty(query.ComponentPath) 
                ? this.GetPage(path, query.IsPreview) 
                : this.GetFragment(path, query.ComponentPath.ParseComponentPath());
        }

        private Negotiator GetPage(IEnumerable<string> path, bool preview)
        {
            var result = this.renderingService.GetPage(path, preview);

            return result.Accept(new PageInstanceNegotiatingResultVisitor(this));
        }

        private Negotiator GetFragment(IEnumerable<string> path, IEnumerable<int> componentPath)
        {
            var result = this.renderingService.GetFragment(path, componentPath);

            return result.Accept(new ComponentInstanceNegotiatingResultVisitor(this));
        }
    }
}