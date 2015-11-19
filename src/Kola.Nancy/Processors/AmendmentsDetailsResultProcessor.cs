namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Models;

    public class AmendmentsDetailsJsonResultProcessor : JsonResultProcessor<AmendmentsDetails>
    {
        public AmendmentsDetailsJsonResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<AmendmentsDetails> builder)
            : base(serializers, builder)
        {
        }
    }
}