namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services;
    using Kola.Service.Services.Models;

    public class ComponentResultProcessor : ResultProcessor<TemplateAndComponent>
    {
        public ComponentResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<TemplateAndComponent> builder)
            : base(serializers, builder)
        {
        }
    }
}