namespace Kola.Nancy.Processors
{
    using System;
    using System.Collections.Generic;

    using global::Nancy;
    using global::Nancy.Responses.Negotiation;
    using global::Nancy.ViewEngines;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    public class ViewProcessor : IResponseProcessor
    {
        private readonly IViewFactory viewFactory;

        public ViewProcessor(IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get { yield break; }
        }

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return new ProcessorMatch
            {
                ModelResult = model is IResult<PageInstance>
                                   ? MatchResult.ExactMatch
                                   : MatchResult.NoMatch,
                RequestedContentTypeResult = requestedMediaRange.Matches("text/html")
                                   ? MatchResult.ExactMatch
                                   : MatchResult.NoMatch
            };
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var result = (IResult<PageInstance>)model;

            return result.Accept(new ResponseBuildingPageResultVisitor(this.viewFactory, context));
        }
    }
}
