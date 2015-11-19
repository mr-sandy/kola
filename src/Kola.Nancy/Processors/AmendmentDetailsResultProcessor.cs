namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Models;

    public class AmendmentDetailsJsonResultProcessor : JsonResultProcessor<AmendmentDetails>
    {
        public AmendmentDetailsJsonResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<AmendmentDetails> builder)
            : base(serializers, builder)
        {
        }
    }
}