namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;

    internal static class PropertyExtensions
    {
        public static Property Find(this IEnumerable<Property> properties, string propertyName)
        {
            return properties.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
        }
    }
}