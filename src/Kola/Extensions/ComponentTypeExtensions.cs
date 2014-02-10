namespace Kola.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;
    using Kola.Resources;

    internal static class ComponentTypeExtensions
    {
        public static ComponentTypeResource ToResource(this INamedComponentSpecification<INamedComponentTemplate> component)
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

        public static IEnumerable<ComponentTypeResource> ToResource(this IEnumerable<INamedComponentSpecification<INamedComponentTemplate>> components)
        {
            return components.Select(ToResource);
        }
    }
}