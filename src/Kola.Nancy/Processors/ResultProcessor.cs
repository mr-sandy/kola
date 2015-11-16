namespace Kola.Nancy.Processors
{
    using System;
    using System.Collections.Generic;

    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Results;

    public abstract class ResultProcessor<T> : Processor<IResult<T>>
    {
        private readonly IResourceBuilder<T> builder;

        protected ResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<T> builder)
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
}