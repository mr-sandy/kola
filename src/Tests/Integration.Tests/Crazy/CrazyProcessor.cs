//namespace Integration.Tests.Crazy
//{
//    using System.Collections.Generic;

//    using global::Nancy;

//    using Kola.Service.ResourceBuilding;

//    public class CrazyProcessor : Processor<CrazyModel>
//    {
//    //    private readonly ISerializer serialiser;
//    //    private readonly IResourceBuilder<CrazyModel> builder;

//    //    private readonly MediaRange mediaRange = new MediaRange("application/json");

//    //    public CrazyProcessor(IEnumerable<ISerializer> serializers, CrazyResourceBuilder builder)
//    //    {
//    //        this.builder = builder;
//    //        this.serialiser = serializers.FirstOrDefault(x => x.CanSerialize(this.mediaRange.ToString()));
//    //    }

//    //    public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
//    //    {
//    //        return new ProcessorMatch
//    //        {
//    //            ModelResult = model is CrazyModel ? MatchResult.ExactMatch : MatchResult.NoMatch,
//    //            RequestedContentTypeResult = requestedMediaRange.Matches(this.mediaRange) ? MatchResult.ExactMatch : MatchResult.NoMatch
//    //        };
//    //    }

//    //    public Response Process(MediaRange requestedMediaRange, dynamic obj, NancyContext context)
//    //    {
//    //        var model = (CrazyModel)obj;

//    //        var resource = this.builder.Build(model);

//    //        return new JsonResponse(resource, this.serialiser);
//    //    }

//    //    public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings => Enumerable.Empty<Tuple<string, MediaRange>>();
//        public CrazyProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<CrazyModel> builder)
//            : base(serializers, builder)
//        {
//        }
//    }
//}