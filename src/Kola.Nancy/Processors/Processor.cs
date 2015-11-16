namespace Kola.Nancy.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    public abstract class Processor<T> : IResponseProcessor
    {
        protected readonly ISerializer Serializer;

        private readonly MediaRange mediaRange = new MediaRange("application/json");

        protected Processor(IEnumerable<ISerializer> serializers)
        {
            this.Serializer = serializers.FirstOrDefault(x => x.CanSerialize(this.mediaRange.ToString()));
            this.ExtensionMappings = new List<Tuple<string, MediaRange>>();
        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings { get; }

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var modelResult = model is T ? MatchResult.ExactMatch : MatchResult.NoMatch;
            var requestedContentTypeResult = requestedMediaRange.Matches(this.mediaRange)
                                                 ? MatchResult.ExactMatch
                                                 : MatchResult.NoMatch;

            return new ProcessorMatch
            {
                ModelResult = modelResult,
                RequestedContentTypeResult = requestedContentTypeResult
            };
        }

        public abstract Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context);
    }
}