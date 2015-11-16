namespace Kola.Nancy.Processors
{
    using System;
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Service.ResourceBuilding;

    public class AmendmentResultProcessor : ResultProcessor<Tuple<Template, IAmendment>>
    {
        public AmendmentResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<Tuple<Template, IAmendment>> builder)
            : base(serializers, builder)
        {
        }
    }
}