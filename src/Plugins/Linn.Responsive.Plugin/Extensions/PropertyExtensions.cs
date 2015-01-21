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
                    { "padding", v => GetClass(v) },
                    { "is-slide", v => GetClassFromBool(v, "slide") },
                    { "margin", v => GetClass(v) },
                    { "pointer-up", v => GetClassFromBool(v, "pointer-up") },
                    { "border", v => GetClass(v) },
                    { "height", v => GetClass(v) },
                    { "width", v => GetClass(v) },
                    { "style", v => GetClass(v, prefix: "style-") },
                    { "show-grids", v => GetClasses(v, "showgrid-") },
                    { "background-colour", v => GetClass(v) },
                    { "text-align", v => GetClass(v, prefix: "text-align-") },
                    { "position", v => GetClasses(v, prefix: "position-") },
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

        private static string GetClasses(string value, string prefix = "", string suffix = "")
        {
            var values = value.Split(new[] { ' ' }).Where(s => !string.IsNullOrWhiteSpace(s));

            var classes = values.Select(val => GetClass(val, string.Empty, prefix, suffix)).Where(c => !string.IsNullOrWhiteSpace(c));

            return string.Join(" ", classes);
        }

        private static string GetClassFromBool(string value, string trueClass = "", string falseClass = "")
        {
            return string.Equals(value, "true", StringComparison.InvariantCultureIgnoreCase)
                       ? !string.IsNullOrWhiteSpace(trueClass) ? trueClass : string.Empty
                       : !string.IsNullOrWhiteSpace(falseClass) ? falseClass : string.Empty;
        }
    }
}