namespace Kola.Nancy.Processors
{
    using System;
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Domain.Composition;
    using Kola.Service.ResourceBuilding;

    public class TemplateResultProcessor : ResultProcessor<Template>
    {
        public TemplateResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<Template> builder)
            : base(serializers, builder)
        {
        }
    }
}
