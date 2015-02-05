namespace Linn.Responsive.Plugin.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    using Linn.Responsive.Plugin.PropertyModels;

    public static class PropertyExtensions
    {
        private static readonly Dictionary<string, Func<string, string>> CssClassHandlers =
            new Dictionary<string, Func<string, string>>
                {
                    { "background-colour", v => BuildClassesFromList<ResponsiveColour>(v, c => string.Format("{0}-back-{1}", c.Colour, c.Grid)) },
                    { "background-colour-hover", v => BuildClassesFromList<ResponsiveColour>(v, c => string.Format("{0}-back-hover-{1}", c.Colour, c.Grid)) },
                    { "border-colour", v => BuildClassesFromList<ResponsiveColour>(v, c => string.Format("border-{0}-{1}", c.Colour, c.Grid)) },
                    { "border-style", v => BuildManyClassesFromList<ResponsiveBorders>(v, ResponsiveBorderClassBuilder.BuildClasses) },
                    { "grid-placement", v => BuildManyClassesFromList<GridPlacement>(v, GridPlacementClassBuilder.BuildClasses) },
                    { "height", v => BuildClassesFromList<ResponsiveHeight>(v, ResponsiveHeightClassBuilder.BuildClasses) },
                    { "is-slide", v => GetClassFromBool(v, "slide") },
                    { "margin", v => BuildManyClassesFromList<ResponsiveEdges>(v, ResponsiveMarginClassBuilder.BuildClasses) },
                    { "max-height", v => BuildClassesFromList<ResponsiveHeight>(v, ResponsiveHeightClassBuilder.BuildClassesForMax) },
                    { "min-height", v => BuildClassesFromList<ResponsiveHeight>(v, ResponsiveHeightClassBuilder.BuildClassesForMin) },
                    { "padding", v => BuildManyClassesFromList<ResponsiveEdges>(v, ResponsivePaddingClassBuilder.BuildClasses) },
                    { "pointer-up", v => GetClassFromBool(v, "pointer-up") },
                    { "position", v => BuildManyClassesFromList<ResponsivePosition>(v, ResponsivePositionClassBuilder.BuildClasses) },
                    { "show-grids", v => EchoClasses(v, "showgrid-") },
                    { "style", v => EchoClass(v, prefix: "style-") },
                    { "text-alignment", v => BuildClassesFromList<ResponsiveAlignment>(v, c => string.Format("text-align-{0}-{1}", c.Alignment.Replace("centre", "center"), c.Grid)) },
                    { "text-colour", v => BuildClassesFromList<ResponsiveColour>(v, c => string.Format("{0}-text-{1}", c.Colour, c.Grid)) },
                    { "text-colour-hover", v => BuildClassesFromList<ResponsiveColour>(v, c => string.Format("{0}-text-hover-{1}", c.Colour, c.Grid)) },
                    { "triangle", v => BuildManyClassesFromList<ResponsiveTriangle>(v, ResponsiveTriangleClassBuilder.BuildClasses) },
                    { "width", v => EchoClass(v) },
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

        private static string EchoClass(string value, string defaultValue = "", string prefix = "", string suffix = "")
        {
            value = !string.IsNullOrEmpty(value)
                        ? value
                        : defaultValue;

            return !string.IsNullOrEmpty(value)
                       ? string.Format("{0}{1}{2}", prefix, value, suffix)
                       : string.Empty;
        }

        private static string EchoClasses(string value, string prefix = "", string suffix = "")
        {
            var values = value.Split(new[] { ' ' }).Where(s => !string.IsNullOrWhiteSpace(s));

            var classes = values.Select(val => EchoClass(val, string.Empty, prefix, suffix)).Where(c => !string.IsNullOrWhiteSpace(c));

            return string.Join(" ", classes);
        }

        private static string GetClassFromBool(string value, string trueClass = "", string falseClass = "")
        {
            return string.Equals(value, "true", StringComparison.InvariantCultureIgnoreCase)
                       ? !string.IsNullOrWhiteSpace(trueClass) ? trueClass : string.Empty
                       : !string.IsNullOrWhiteSpace(falseClass) ? falseClass : string.Empty;
        }

        private static string BuildClassesFromList<T>(string raw, Func<T, string> builder)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var settings = serializer.Deserialize<IEnumerable<T>>(raw);

            var classNames = settings.Select(builder);

            return string.Join(" ", classNames);
        }

        private static string BuildManyClassesFromList<T>(string raw, Func<T, IEnumerable<string>> builder)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var settings = serializer.Deserialize<IEnumerable<T>>(raw);

            var classNames = settings.Select(builder).SelectMany(s => s);

            return string.Join(" ", classNames);
        }
    }
}