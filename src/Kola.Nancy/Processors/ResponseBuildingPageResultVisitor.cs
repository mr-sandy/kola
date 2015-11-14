namespace Kola.Nancy.Processors
{
    using System;

    using global::Nancy;
    using global::Nancy.Responses;
    using global::Nancy.ViewEngines;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    public class ResponseBuildingPageResultVisitor : IResultVisitor<PageInstance, Response>
    {
        private readonly IViewFactory viewFactory;
        private readonly NancyContext context;

        public ResponseBuildingPageResultVisitor(IViewFactory viewFactory, NancyContext context)
        {
            this.viewFactory = viewFactory;
            this.context = context;
        }

        public Response Visit(SuccessResult<PageInstance> result)
        {
            var page = result.Data;

            var viewResponse = this.viewFactory.RenderView("Page", page, GetViewLocationContext(this.context));

            return StaticConfiguration.DisableErrorTraces ? viewResponse : new MaterialisingResponse(viewResponse);
        }

        public Response Visit(UnauthorisedResult<PageInstance> result)
        {
            throw new NotImplementedException();
        }

        public Response Visit(NotFoundResult<PageInstance> result)
        {
            return new NotFoundResponse();

            //var viewResponse = this.viewFactory.RenderView("404", null, GetViewLocationContext(this.context));
            //viewResponse.StatusCode = HttpStatusCode.NotFound;

            //return StaticConfiguration.DisableErrorTraces ? viewResponse : new MaterialisingResponse(viewResponse);
        }

        public Response Visit(CreatedResult<PageInstance> result)
        {
            throw new NotImplementedException();
        }

        public Response Visit(FailureResult<PageInstance> result)
        {
            throw new NotImplementedException();
        }

        private static ViewLocationContext GetViewLocationContext(NancyContext context)
        {
            return new ViewLocationContext
                       {
                           Context = context,
                           ModuleName = context.NegotiationContext.ModuleName,
                           ModulePath = context.NegotiationContext.ModulePath
                       };
        }
    }
}