namespace Linn.Responsive.Plugin.Extensions
{
    using System.Collections.Generic;

    using Linn.Responsive.Plugin.PropertyModels;

    internal static class GridPlacementClassBuilder
    {
        public static IEnumerable<string> BuildClasses(GridPlacement gridPlacement)
        {
            if (!string.IsNullOrWhiteSpace(gridPlacement.Position))
            {
                yield return
                    string.Equals(gridPlacement.Position, "1-12")
                        ? string.Format("{0}-all", gridPlacement.Grid)
                        : string.Format("{0}{1}", gridPlacement.Grid, gridPlacement.Position.Replace("-", string.Format("-{0}", gridPlacement.Grid)));
            }

            if (gridPlacement.Shown.HasValue)
            {
                yield return string.Format("{0}-show", gridPlacement.Grid);
            }

            if (gridPlacement.Hidden.HasValue)
            {
                yield return string.Format("{0}-hide", gridPlacement.Grid);
            }
        }
    }
}