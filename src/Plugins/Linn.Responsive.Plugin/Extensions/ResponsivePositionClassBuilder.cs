namespace Linn.Responsive.Plugin.Extensions
{
    using System.Collections.Generic;

    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsivePositionClassBuilder
    {
        public static IEnumerable<string> BuildClasses(ResponsivePosition responsivePosition)
        {
            foreach (var position in responsivePosition.Positions)
            {
                switch (position.Position)
                {
                    case "below":
                        yield return string.Format("position-below-{0}-{1}", position.Offset, responsivePosition.Grid);
                        break;

                    case "none":
                        yield return string.Format("position-none-{0}", responsivePosition.Grid);
                        break;

                    default:
                        if (!string.IsNullOrWhiteSpace(position.Offset))
                        {
                            yield return string.Format("position-{0}-{1}-{2}", position.Position.Substring(0, 1), position.Offset, responsivePosition.Grid);
                        }
                        else
                        {
                            yield return string.Format("position-{0}-{1}", position.Position.Substring(0, 1), responsivePosition.Grid);
                        }

                        break;
                }
            }
        }
    }
}