namespace Kola.Nancy.Processors
{
    using global::Nancy;
    using global::Nancy.Responses.Negotiation;
    using global::Nancy.ViewEngines;

    using Kola.Service.Services.Results;

    public abstract class ViewResultProcessor<T> : Processor<IResult<T>>
    {
        private readonly IViewFactory viewFactory;

        protected ViewResultProcessor(IViewFactory viewFactory)
            : base(new MediaRange("text/html"))
        {
            this.viewFactory = viewFactory;
        }

        public override Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var result = (IResult<T>)model;

            var responseBuilder = new ViewResponseResultVisitor<T>(this.viewFactory, context);

            return result.Accept(responseBuilder);
        }
    }
}