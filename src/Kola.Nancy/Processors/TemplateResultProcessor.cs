namespace Kola.Nancy.Processors
{
    using System;
    using System.Collections.Generic;

    using global::Nancy;
    using global::Nancy.Responses.Negotiation;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Rendering;
    using Kola.Resources;
    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Results;

    //public class TemplateResultProcessor : ResultProcessor<Template>
    //{
    //    private readonly IResourceBuilder<Template> builder;

    //    public TemplateResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<Template> builder)
    //        : base(serializers)
    //    {
    //        this.builder = builder;
    //    }

    //    public override Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
    //    {
    //        var result = (IResult<Template>)model;

    //        var responseBuilder = new ResponseBuildingResultVisitor<Template>(this.builder, this.Serializer);

    //        return result.Accept(responseBuilder);
    //    }
    //}

    //public class AmendmentResultProcessor : ResultProcessor<Tuple<Template, IAmendment>>
    //{
    //    private readonly IResourceBuilder<Tuple<Template, IAmendment>> builder;

    //    public AmendmentResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<Tuple<Template, IAmendment>> builder)
    //        : base(serializers)
    //    {
    //        this.builder = builder;
    //    }

    //    public override Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
    //    {
    //        var result = (IResult<Tuple<Template, IAmendment>>)model;

    //        var responseBuilder = new ResponseBuildingResultVisitor<Tuple<Template, IAmendment>>(this.builder, this.Serializer);

    //        return result.Accept(responseBuilder);
    //    }
    //}
}
