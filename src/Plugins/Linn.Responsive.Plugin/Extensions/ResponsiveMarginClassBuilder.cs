namespace Linn.Responsive.Plugin.Extensions
{
    using System.Collections.Generic;

    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsiveMarginClassBuilder
    {
        public static IEnumerable<string> BuildClasses(ResponsiveEdges responsivePadding)
        {
            foreach (var edge in responsivePadding.Edges)
            {
                if (!string.IsNullOrWhiteSpace(edge.Value))
                {
                    yield return string.Format("margin-{0}-{1}-{2}", edge.Edge.Substring(0, 1), edge.Value.Replace(".5", "-and-a-half"), responsivePadding.Grid);
                }
            }
        }
    }
}