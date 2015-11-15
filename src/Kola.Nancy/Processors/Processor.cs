namespace Kola.Nancy.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    using Kola.Domain.Composition;
    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Results;

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

    public class ResultProcessor<T> : Processor<IResult<T>>
    {
        private readonly IResourceBuilder<T> builder;

        public ResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<T> builder )
            : base(serializers)
        {
            this.builder = builder;
        }

        public override Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var result = (IResult<T>)model;

            var responseBuilder = new ResponseBuildingResultVisitor<T>(this.builder, this.Serializer);

            return result.Accept(responseBuilder);
        }
    }

    public class TemplateResultProcessor : ResultProcessor<Template>
    {
        public TemplateResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<Template> builder)
            : base(serializers, builder)
        {
        }
    }
}