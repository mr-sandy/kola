namespace Kola.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;
    using Kola.Extensions;
    using Kola.Resources;

    internal class ComponentTypeResourceBuilder
    {
        private readonly ComponentNamingSpecificationVisitor namingVisitor = new ComponentNamingSpecificationVisitor();

        public ComponentTypeResource Build(IComponentSpecification<IComponentWithProperties> component)
        {
            return new ComponentTypeResource
                {
                    Name = component.Name,
                    Type = component.Accept(this.namingVisitor),
                    Links = new[]
                        {
                            new LinkResource { Rel = "self", Href = "/_kola/component-types/" + component.Name.Urlify() }
                        }
                };
        }

        public IEnumerable<ComponentTypeResource> Build(IEnumerable<IComponentSpecification<IComponentWithProperties>> components)
        {
            return components.Select(this.Build);
        }
    }
}