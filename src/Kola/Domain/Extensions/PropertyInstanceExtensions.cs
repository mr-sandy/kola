namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public static class PropertyInstanceExtensions
    {
        public static string Get(this IEnumerable<PropertyInstance> properties, string propertyName, string fallback = "", string format = null)
        {
            var property = properties.Where(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return property == null
                       ? fallback
                       : format == null || string.IsNullOrWhiteSpace(property.Value)
                             ? property.Value
                             : string.Format(format, property.Value);
        }

        public static string GetAsAttribute(this IEnumerable<PropertyInstance> properties, string propertyName)
        {
            return properties.Get(propertyName, string.Empty, string.Format("{0}=\"{{0}}\" ", propertyName));
        }
    }
}