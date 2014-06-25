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
        public ComponentTypeResource Build(IParameterisedComponentSpecification<IParameterisedComponent> component)
        {
            return new ComponentTypeResource
                {
                    Name = component.Name,
                    Links = new[]
                        {
                            new LinkResource { Rel = "self", Href = "/_kola/component-types/" + component.Name.Urlify() }
                        }
                };
        }

        public IEnumerable<ComponentTypeResource> Build(IEnumerable<IParameterisedComponentSpecification<IParameterisedComponent>> components)
        {
            return components.Select(this.Build);
        }

    }
}