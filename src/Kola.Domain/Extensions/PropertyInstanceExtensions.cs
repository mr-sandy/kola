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
            var property = properties.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

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

            return string.Format("{0}=\"{1}\"", attributeName, attributeValue);
        }

        public static string GetAsAttributeWithStaticUri(this IEnumerable<PropertyInstance> properties, string hrefPropertyName = "href", string cacheBusterPropertyName = "cache-buster", string attributeName = "")
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

            return string.Format("{0}=\"{1}\"", attributeName, href.StrongTrim().ToStaticHostUri(cacheBuster));
        }

        public static string GetAsStaticUri(this IEnumerable<PropertyInstance> properties, string hrefPropertyName = "href", string cacheBusterPropertyName = "cache-buster")
        {
            var href = properties.Get(hrefPropertyName);
            var cacheBuster = properties.Get(cacheBusterPropertyName);

            if (string.IsNullOrWhiteSpace(href))
            {
                return string.Empty;
            }

            return href.StrongTrim().ToStaticHostUri(cacheBuster).ToString();
        }

        public static bool GetAsBool(this IEnumerable<PropertyInstance> properties, string propertyName)
        {
            return string.Equals(properties.Get(propertyName), "true", StringComparison.InvariantCultureIgnoreCase);
        }

        public static string WrapInCondition(this string html, string condition)
        {
            var format = "{0}";

            switch (condition)
            {
                case "gt8":
                    format = "<!--[if (!IE) | (gt IE 8)]><!-->\n    {0}\n    <!--<![endif]-->";
                    break;
                case "gt9":
                    format = "<!--[if (!IE) | (gt IE 9)]><!-->\n    {0}\n    <!--<![endif]-->";
                    break;
                case "9":
                    format = "<!--[if IE 9]>\n    {0}\n    <![endif]-->";
                    break;
                case "lt9":
                    format = "<!--[if lt IE 9]>\n    {0}\n    <![endif]-->";
                    break;
                case "lte8":
                    format = "<!--[if lte IE 8]>\n    {0}\n    <![endif]-->";
                    break;
            }

            return string.Format(format, html);
        }
    }
}