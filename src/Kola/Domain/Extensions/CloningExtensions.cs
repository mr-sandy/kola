namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;

    internal static class CloningExtensions
    {
        internal static IEnumerable<MultilingualVariant> Clone(this IEnumerable<MultilingualVariant> variants)
        {
            return variants.Select(v => v.Clone());
        }

        internal static IEnumerable<Property> Clone(this IEnumerable<Property> properties)
        {
            return properties.Select(p => p.Clone());
        }

        internal static IEnumerable<Area> Clone(this IEnumerable<Area> areas)
        {
            return areas.Select(a => (Area)a.Clone());
        }

        internal static IEnumerable<IComponent> Clone(this IEnumerable<IComponent> components)
        {
            return components.Select(a => a.Clone());
        }
    }
}