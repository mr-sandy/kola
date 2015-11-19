namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Models;

    public class UndoAmendmentDetailsJsonResultProcessor : JsonResultProcessor<UndoAmendmentDetails>
    {
        public UndoAmendmentDetailsJsonResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<UndoAmendmentDetails> builder)
            : base(serializers, builder)
        {
        }
    }
}