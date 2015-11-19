namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;
    using System.Linq;

    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Results;

    public abstract class JsonResultProcessor<T> : Processor<IResult<T>>
    {
        protected readonly ISerializer Serializer;
        private readonly IResourceBuilder<T> builder;

        protected JsonResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<T> builder)
            : base(new MediaRange("application/json"))
        {
            this.Serializer = serializers.FirstOrDefault(x => x.CanSerialize(this.MediaRange.ToString()));
            this.builder = builder;
        }

        public override Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var result = (IResult<T>)model;

            var responseBuilder = new JsonResponseResultVisitor<T>(this.builder, this.Serializer);

            return result.Accept(responseBuilder);
        }
    }
}