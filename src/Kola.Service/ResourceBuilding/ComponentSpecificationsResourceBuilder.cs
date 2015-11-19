namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public class ComponentSpecificationsResourceBuilder : IResourceBuilder<IEnumerable<IComponentSpecification<IComponentWithProperties>>>
    {
        public object Build(IEnumerable<IComponentSpecification<IComponentWithProperties>> componentSpecifications)
        {
            return new ComponentTypeResourceBuilder().Build(componentSpecifications).OrderBy(c => c.Type).ThenBy(c => c.Name);
        }

        public string Location(IEnumerable<IComponentSpecification<IComponentWithProperties>> componentSpecifications)
        {
            throw new System.NotImplementedException();
        }
    }
}
