namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Domain.Specifications;
    using Kola.Service.ResourceBuilding;

    public class WidgetSpecificationResultProcessor : ResultProcessor<WidgetSpecification>
    {
        public WidgetSpecificationResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<WidgetSpecification> builder)
            : base(serializers, builder)
        {
        }
    }
}