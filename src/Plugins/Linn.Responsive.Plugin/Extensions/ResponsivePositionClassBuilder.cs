namespace Linn.Responsive.Plugin.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsivePositionClassBuilder
    {
        public static IEnumerable<string> BuildClasses(ResponsivePosition responsivePosition)
        {
            switch (responsivePosition.Position)
            {
                case "below":
                    yield return string.Format("position-below-{0}-{1}", responsivePosition.Offset, responsivePosition.Grid);
                    break;

                case "none":
                    yield return string.Format("position-none-{0}", responsivePosition.Grid);
                    break;

                default:
                    var positions = responsivePosition.Position.Split(new[] { ' ' }).Where(s => !string.IsNullOrWhiteSpace(s));
                    foreach (var position in positions)
                    {
                        yield return string.Format("position-{0}-{1}", position.Substring(0, 1), responsivePosition.Grid);
                    }
                    break;
            }
        }
    }
}