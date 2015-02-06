namespace Linn.Responsive.Plugin.Extensions
{
    using System.Collections.Generic;

    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsiveFloatClassBuilder
    {
        public static IEnumerable<string> BuildClasses(ResponsiveFloat responsiveFloat)
        {
            switch (responsiveFloat.Float)
            {
                case "left":
                    yield return string.Format("{0}-floatleft", responsiveFloat.Grid);
                    break;

                case "right":
                    yield return string.Format("{0}-floatright", responsiveFloat.Grid);
                    break;

                case "none":
                    yield return string.Format("nofloat-{0}", responsiveFloat.Grid);
                    break;
            }

            switch (responsiveFloat.Clear)
            {
                case "left":
                    yield return string.Format("{0}-clear", responsiveFloat.Grid);
                    break;
            }
        }
    }
}