namespace Kola.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;
    using Kola.Resources;

    internal static class ComponentTypeExtensions
    {
        public static ComponentTypeResource ToResource(this ComponentType componentType)
        {
            return new ComponentTypeResource
                {
                    Name = componentType.Name,
                    Links = new[]
                        {
                            new LinkResource { Rel = "self", Href = "/_kola/component-types/" + componentType.Name.Urlify() }
                        }
                };
        }

        public static IEnumerable<ComponentTypeResource> ToResource(this IEnumerable<ComponentType> componentTypes)
        {
            return componentTypes.Select(ToResource);
        }
    }
}