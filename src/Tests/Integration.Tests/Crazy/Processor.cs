//namespace Integration.Tests.Crazy
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    using global::Nancy;
//    using global::Nancy.Responses;
//    using global::Nancy.Responses.Negotiation;

//    using Kola.Service.ResourceBuilding;

//    public abstract class Processor<T> : IResponseProcessor
//    {
//        private readonly ISerializer serialiser;
//        private readonly IResourceBuilder<T> builder;

//        private readonly MediaRange mediaRange = new MediaRange("application/json");

//        protected Processor(IEnumerable<ISerializer> serializers, IResourceBuilder<T> builder)
//        {
//            this.builder = builder;
//            this.serialiser = serializers.FirstOrDefault(x => x.CanSerialize(this.mediaRange.ToString()));
//        }

//        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
//        {
//            return new ProcessorMatch
//            {
//                ModelResult = model is T ? MatchResult.ExactMatch : MatchResult.NoMatch,
//                RequestedContentTypeResult = requestedMediaRange.Matches(this.mediaRange) ? MatchResult.ExactMatch : MatchResult.NoMatch
//            };
//        }

//        public Response Process(MediaRange requestedMediaRange, dynamic obj, NancyContext context)
//        {
//            var model = (T)obj;

//            var resource = this.builder.Build(model);

//            return new JsonResponse(resource, this.serialiser);
//        }

//        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings => Enumerable.Empty<Tuple<string, MediaRange>>();
//    }
//}