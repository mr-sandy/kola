namespace Kola.Nancy.Processors
{
    using System;
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services;
    using Kola.Service.Services.Models;

    public class AmendmentResultProcessor : ResultProcessor<TemplateAndAmendment>
    {
        public AmendmentResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<TemplateAndAmendment> builder)
            : base(serializers, builder)
        {
        }
    }
}