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
        private readonly string viewName;
        private readonly Action<Response, T> responseDecorator;

        public ViewResponseResultVisitor(IViewFactory viewFactory, NancyContext context, string viewName, Action<Response, T> responseDecorator)
        {
            this.viewFactory = viewFactory;
            this.context = context;
            this.viewName = viewName;
            this.responseDecorator = responseDecorator;
        }

        public Response Visit(SuccessResult<T> result)
        {
            var viewResponse = this.viewFactory.RenderView(this.viewName, result.Data, GetViewLocationContext(this.context));

            var response = StaticConfiguration.DisableErrorTraces ? viewResponse : new MaterialisingResponse(viewResponse);

            this.responseDecorator?.Invoke(response, result.Data);

            return response;
        }

        public Response Visit(UnauthorisedResult<T> result)
        {
            throw new NotImplementedException();
        }

        public Response Visit(NotFoundResult<T> result)
        {
            var viewResponse = this.viewFactory.RenderView("404", null, GetViewLocationContext(this.context));

            return viewResponse.WithStatusCode(HttpStatusCode.NotFound);

            //return new NotFoundResponse();
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