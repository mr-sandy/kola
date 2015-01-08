namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public static class PropertyInstanceExtensions
    {
        public static string Get(this IEnumerable<PropertyInstance> properties, string propertyName, string fallback = "")
        {
            var property = properties.Where(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return property == null
                ? fallback
                : property.Value;
        }
    }
}