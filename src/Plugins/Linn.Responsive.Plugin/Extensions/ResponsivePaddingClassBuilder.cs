namespace Linn.Responsive.Plugin.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsivePaddingClassBuilder
    {
        public static IEnumerable<string> BuildClasses(ResponsiveEdges responsivePadding)
        {
            return responsivePadding.Edges.Where(edge => !string.IsNullOrWhiteSpace(edge.Value))
                .Select(edge =>
                    string.Format(
                        "pad-{0}-{1}-{2}",
                        edge.Edge.Substring(0, 1),
                        edge.Value.Replace(".5", "-and-a-half"),
                        responsivePadding.Grid));
        }
    }
}