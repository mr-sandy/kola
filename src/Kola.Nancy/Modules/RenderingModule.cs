namespace Kola.Nancy.Modules
{
    using System.Collections.Generic;

    using global::Nancy;
    using global::Nancy.ModelBinding;
    using global::Nancy.Responses;
    using global::Nancy.Responses.Negotiation;

    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;
    using Kola.Nancy.Extensions;
    using Kola.Service.Services;
    using Kola.Service.Services.Results;

    public class RenderingModule : NancyModule
    {
        private readonly IRenderingService renderingService;

        public RenderingModule(IRenderingService renderingService)
        {
            this.renderingService = renderingService;
            this.Get["/"] = p => this.GetResponse();
            this.Get["/(.*)"] = p => this.GetResponse();
            this.Get["/{path*}"] = p => this.GetResponse();
        }

        private Negotiator GetResponse()
        {
            var query = this.Bind<RenderQuery>();

            return string.IsNullOrEmpty(query.ComponentPath) 
                ? this.GetPage(query) 
                : this.GetFragment(query);
        }

        private Negotiator GetPage(RenderQuery query)
        {
            var path = this.Request.Path.ParsePath();

            var renderingInstructions = new RenderingInstructions(useCache: !query.IsPreview, annotateComponentPaths: query.IsPreview);

            var result = this.renderingService.GetPage(path, renderingInstructions);

            return result.Accept(new PageInstanceNegotiatingResultVisitor(this));
        }

        private Negotiator GetFragment(RenderQuery query)
        {
            var path = this.Request.Path.ParsePath();

            var renderingInstructions = new RenderingInstructions(useCache: false, annotateComponentPaths: true);

            var componentPath = query.ComponentPath.ParseComponentPath();

            var result = this.renderingService.GetFragment(path, renderingInstructions, componentPath);

            return result.Accept(new ComponentInstanceNegotiatingResultVisitor(this));
        }
    }
}