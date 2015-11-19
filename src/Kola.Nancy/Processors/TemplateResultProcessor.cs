namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Domain.Composition;
    using Kola.Service.ResourceBuilding;

    public class TemplateJsonResultProcessor : JsonResultProcessor<Template>
    {
        public TemplateJsonResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<Template> builder)
            : base(serializers, builder)
        {
        }
    }
}
