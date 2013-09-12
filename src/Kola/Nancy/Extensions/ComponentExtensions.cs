namespace Kola.Nancy.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;
    using Kola.Resources;

    internal static class ComponentExtensions
    {
        public static ComponentResource ToResource(this Component component, string rootUri, int index)
        {
            var uri = string.Format("/{0}/{1}", rootUri, index);
            return new ComponentResource
            {
                Components = component.Components.ToResource(uri),

                Links = new[]
                            {
                                new LinkResource
                                    {
                                        Rel = "self", 
                                        Href = uri
                                    }
                            }
            };
        }

        public static IEnumerable<ComponentResource> ToResource(this IEnumerable<Component> components, string rootUri)
        {
            var result = new List<ComponentResource>();

            for (var i = 0; i < components.Count(); i++)
            {
                result.Add(components.ElementAt(i).ToResource(rootUri, i));
            }
             
            return result;
        }
    }
}