namespace Linn.Responsive.Plugin.Extensions
{
    using System.Collections.Generic;

    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsiveFontClassBuilder
    {
        public static IEnumerable<string> BuildClasses(ResponsiveFont responsiveFont)
        {
            if (!string.IsNullOrWhiteSpace(responsiveFont.FontSize))
            {
                yield return string.Format("font-size-{0}-{1}", responsiveFont.FontSize, responsiveFont.Grid);
            }

            if (!string.IsNullOrWhiteSpace(responsiveFont.FontWeight))
            {
                yield return string.Format("font-weight-{0}-{1}", responsiveFont.FontWeight, responsiveFont.Grid);
            }

            if (!string.IsNullOrWhiteSpace(responsiveFont.LineHeight))
            {
                yield return string.Format("line-height-{0}-{1}", responsiveFont.LineHeight, responsiveFont.Grid);
            }
        }
    }
}