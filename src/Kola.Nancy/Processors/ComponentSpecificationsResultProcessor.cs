namespace Kola.Nancy.Processors
{
    using System.Collections.Generic;

    using global::Nancy;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;
    using Kola.Service.ResourceBuilding;

    public class ComponentSpecificationsJsonResultProcessor : JsonResultProcessor<IEnumerable<IComponentSpecification<IComponentWithProperties>>>
    {
        public ComponentSpecificationsJsonResultProcessor(IEnumerable<ISerializer> serializers, IResourceBuilder<IEnumerable<IComponentSpecification<IComponentWithProperties>>> builder)
            : base(serializers, builder)
        {
        }
    }
}