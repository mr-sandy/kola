namespace Linn.Responsive.Plugin.Extensions
{
    using System.Collections.Generic;

    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsiveTriangleClassBuilder
    {
        public static IEnumerable<string> BuildClasses(ResponsiveTriangle responsiveTriangle)
        {
            if (!string.IsNullOrWhiteSpace(responsiveTriangle.Edge))
            {
                yield return string.Format("triangle-{0}-{1}", responsiveTriangle.Edge.Substring(0, 1), responsiveTriangle.Grid);

                if (responsiveTriangle.Centred.HasValue && responsiveTriangle.Centred.Value)
                {
                    yield return string.Format("triangle-centre-{0}", responsiveTriangle.Grid);
                }
            }
        }
    }
}