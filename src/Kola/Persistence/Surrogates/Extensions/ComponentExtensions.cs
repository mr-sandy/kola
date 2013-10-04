namespace Kola.Persistence.Surrogates.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;

    public static class ComponentExtensions
    {
        public static ComponentSurrogate ToSurrogate(this Component component)
        {
            return new ComponentSurrogate();
        }

        public static IEnumerable<ComponentSurrogate> ToSurrogate(this IEnumerable<Component> components)
        {
            return components.Select(ToSurrogate);
        }
    }
}