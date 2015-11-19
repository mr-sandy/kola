namespace Kola.Nancy.Processors
{
    using System;

    using global::Nancy;
    using global::Nancy.Responses;
    using global::Nancy.ViewEngines;

    using Kola.Service.Services.Results;

    public class ViewResponseResultVisitor<T> : ResponseResultVisitor<T>
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

        public override Response Visit(SuccessResult<T> result)
        {
            var viewResponse = this.viewFactory.RenderView(this.viewName, result.Data, GetViewLocationContext(this.context));

            var response = StaticConfiguration.DisableErrorTraces ? viewResponse : new MaterialisingResponse(viewResponse);

            this.responseDecorator?.Invoke(response, result.Data);

            return response;
        }

        public override Response Visit(NotFoundResult<T> result)
        {
            var viewResponse = this.viewFactory.RenderView("404", null, GetViewLocationContext(this.context));

            return viewResponse.WithStatusCode(HttpStatusCode.NotFound);

            //return new NotFoundResponse();
        }

        public override Response Visit(MovedPermanentlyResult<T> result)
        {
            return new Response()
                .WithStatusCode(HttpStatusCode.MovedPermanently)
                .WithHeader("Location", result.Location);
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