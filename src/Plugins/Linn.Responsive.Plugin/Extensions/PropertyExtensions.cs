namespace Linn.Responsive.Plugin.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public static class PropertyExtensions
    {
        private static readonly Dictionary<string, Func<string, string>> CssClassHandlers =
            new Dictionary<string, Func<string, string>>
                {
                    { "grid-placement", v => GetClass(v) },
                    { "padding", v => GetClass(v) }
                };

        public static string GetClassNames(this IEnumerable<PropertyInstance> properties)
        {
            return string.Join(" ", properties.Select(GetClassNames).Where(c => !string.IsNullOrEmpty(c)));
        }

        private static string GetClassNames(PropertyInstance property)
        {
            Func<string, string> handler;

            return CssClassHandlers.TryGetValue(property.Name, out handler)
                ? handler(property.Value)
                : string.Empty;
        }

        private static string GetClass(string value, string defaultValue = "", string prefix = "", string suffix = "")
        {
            value = !string.IsNullOrEmpty(value)
                        ? value
                        : defaultValue;

            return !string.IsNullOrEmpty(value)
                       ? string.Format("{0}{1}{2}", prefix, value, suffix)
                       : string.Empty;
        }

    }
}