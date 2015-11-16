namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Domain.Composition.Amendments;
    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Models;

    public class AmendmentsResultProcessor : ResultProcessor<TemplateAndAmendments>
    {
        public AmendmentsResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<TemplateAndAmendments> builder)
            : base(serializers, builder)
        {
        }
    }
}