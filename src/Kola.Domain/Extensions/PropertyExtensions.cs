namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;

    public static class PropertyExtensions
    {
        public static Property Find(this IEnumerable<Property> properties, string propertyName)
        {
            return properties.Where(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
    }
}