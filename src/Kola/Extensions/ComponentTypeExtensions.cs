namespace Kola.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;
    using Kola.Resources;

    internal static class ComponentTypeExtensions
    {
        public static ComponentTypeResource ToResource(this IParameterisedComponentSpecification<IParameterisedComponent> component)
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

        public static IEnumerable<ComponentTypeResource> ToResource(this IEnumerable<IParameterisedComponentSpecification<IParameterisedComponent>> components)
        {
            return components.Select(ToResource);
        }
    }
}