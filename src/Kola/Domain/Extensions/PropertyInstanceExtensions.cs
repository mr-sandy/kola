namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Extensions;

    public static class PropertyInstanceExtensions
    {
        public static string Get(this IEnumerable<PropertyInstance> properties, string propertyName, string fallback = "")
        {
            var property = properties.Where(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return property == null
                ? fallback
                : property.Value;
        }

        public static string GetAsAttribute(this IEnumerable<PropertyInstance> properties, string propertyName, string attributeName = "")
        {
            var attributeValue = properties.Get(propertyName);

            if (string.IsNullOrWhiteSpace(attributeValue))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(attributeName))
            {
                attributeName = propertyName;
            }

            return string.Format("{0}=\"{1}\" ", attributeName, attributeValue);
        }

        public static string GetAsStaticUri(this IEnumerable<PropertyInstance> properties, string hrefPropertyName = "href", string cacheBusterPropertyName = "cache-buster", string attributeName = "")
        {
            var href = properties.Get(hrefPropertyName);
            var cacheBuster = properties.Get(cacheBusterPropertyName);

            if (string.IsNullOrWhiteSpace(href))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(attributeName))
            {
                attributeName = hrefPropertyName;
            }

            return string.Format("{0}=\"{1}\" ", attributeName, href.StrongTrim().ToStaticHostUri(cacheBuster));
        }
    }
}