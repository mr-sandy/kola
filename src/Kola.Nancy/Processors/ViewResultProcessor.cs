namespace Kola.Nancy.Processors
{
    using global::Nancy;
    using global::Nancy.Responses.Negotiation;
    using global::Nancy.ViewEngines;

    using Kola.Service.Services.Results;

    public abstract class ViewResultProcessor<T> : Processor<IResult<T>>
    {
        private readonly IViewFactory viewFactory;

        private readonly string viewName;

        protected ViewResultProcessor(IViewFactory viewFactory, string viewName)
            : base(new MediaRange("text/html"))
        {
            this.viewFactory = viewFactory;
            this.viewName = viewName;
        }

        protected virtual void ResponseDecorator(Response response, T model)
        {
        }

        public override Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var result = (IResult<T>)model;

            var responseBuilder = new ViewResponseResultVisitor<T>(this.viewFactory, context, this.viewName, this.ResponseDecorator);

            return result.Accept(responseBuilder);
        }
    }
}