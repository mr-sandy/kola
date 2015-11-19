namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Models;

    public class ComponentDetailsResultProcessor : ResultProcessor<ComponentDetails>
    {
        public ComponentDetailsResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<ComponentDetails> builder)
            : base(serializers, builder)
        {
        }
    }
}