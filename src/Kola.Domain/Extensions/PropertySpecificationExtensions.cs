namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Specifications;

    internal static class PropertySpecificationExtensions
    {
        public static PropertySpecification Find(this IEnumerable<PropertySpecification> properties, string propertyName)
        {
            return properties.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
        }
    }
}