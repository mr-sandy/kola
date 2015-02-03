namespace Linn.Responsive.Plugin.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsiveBorderClassBuilder
    {
        public static IEnumerable<string> BuildClasses(ResponsiveBorders responsiveBorders)
        {
            return responsiveBorders.Borders.Where(border => !string.IsNullOrWhiteSpace(border.Width))
                .Select(border =>
                        string.Format(
                            "border-{0}-{1}-{2}",
                            border.Border.Substring(0, 1),
                            border.Width,
                            responsiveBorders.Grid));
        }
    }
}