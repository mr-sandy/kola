namespace Kola.Nancy.Processors
{
    using System;
    using System.Collections.Generic;

    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    public abstract class Processor<T> : IResponseProcessor
    {
        protected readonly MediaRange MediaRange;

        protected Processor(MediaRange mediaRange)
        {
            this.MediaRange = mediaRange;
        }

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return new ProcessorMatch
                       {
                           ModelResult = model is T 
                                            ? MatchResult.ExactMatch 
                                            : MatchResult.NoMatch,
                           RequestedContentTypeResult = requestedMediaRange.Matches(this.MediaRange)
                                            ? MatchResult.ExactMatch
                                            : MatchResult.NoMatch
                       };
        }

        public abstract Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context);

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get { yield break; }
        }
    }
}