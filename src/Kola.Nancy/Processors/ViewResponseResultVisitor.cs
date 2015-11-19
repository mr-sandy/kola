namespace Kola.Nancy.Processors
{
    using System;
    using System.Runtime.Remoting;

    using global::Nancy;
    using global::Nancy.Responses;
    using global::Nancy.ViewEngines;

    using Kola.Service.Services.Results;

    public class ViewResponseResultVisitor<T> : IResultVisitor<T, Response>
    {
        private readonly IViewFactory viewFactory;
        private readonly NancyContext context;

        public ViewResponseResultVisitor(IViewFactory viewFactory, NancyContext context)
        {
            this.viewFactory = viewFactory;
            this.context = context;
        }

        public Response Visit(SuccessResult<T> result)
        {
            var viewResponse = this.viewFactory.RenderView("Page", result.Data, GetViewLocationContext(this.context));

            var response = StaticConfiguration.DisableErrorTraces ? viewResponse : new MaterialisingResponse(viewResponse);

            return response;

            //    return result.Data.RenderingInstructions.UseCache
            //        ? response.WithHeader("Cache-Control", "public, max-age=600")
            //        : response.WithHeader("Cache-Control", "no-cache");
        }

        public Response Visit(UnauthorisedResult<T> result)
        {
            throw new NotImplementedException();
        }

        public Response Visit(NotFoundResult<T> result)
        {
            return new NotFoundResponse();
        }

        public Response Visit(CreatedResult<T> result)
        {
            throw new NotImplementedException();
        }

        public Response Visit(FailureResult<T> result)
        {
            throw new NotImplementedException();
        }

        public Response Visit(ConflictResult<T> result)
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