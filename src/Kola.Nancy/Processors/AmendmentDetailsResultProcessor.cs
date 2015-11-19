namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Models;

    public class AmendmentDetailsResultProcessor : ResultProcessor<AmendmentDetails>
    {
        public AmendmentDetailsResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<AmendmentDetails> builder)
            : base(serializers, builder)
        {
        }
    }
}