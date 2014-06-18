//namespace Kola.Nancy.ResponseProcessors
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    using global::Nancy;
//    using global::Nancy.Responses.Negotiation;

//    public abstract class Processor<T> : IResponseProcessor
//    {
//        protected readonly ISerializer Serializer;

//        private readonly IEnumerable<MediaRange> supportedRanges;

//        protected Processor(IEnumerable<ISerializer> serializers, IEnumerable<MediaRange> supportedRanges, string serializationType = "application/json")
//        {
//            this.supportedRanges = supportedRanges;
//            this.Serializer = serializers.FirstOrDefault(x => x.CanSerialize(serializationType));
//        }

//        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
//        {
//            get
//            {
//                return new List<Tuple<string, MediaRange>>();
//            }
//        }

//        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
//        {
//            var modelResult = model is T ? MatchResult.ExactMatch : MatchResult.NoMatch;
//            var requestedContentTypeResult = this.supportedRanges.Any(r => r.MatchesWithParameters(requestedMediaRange))
//                                                    ? MatchResult.ExactMatch
//                                                    : MatchResult.NoMatch;

//            return new ProcessorMatch
//            {
//                ModelResult = modelResult,
//                RequestedContentTypeResult = requestedContentTypeResult
//            };
//        }

//        public abstract Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context);
//    }
//}