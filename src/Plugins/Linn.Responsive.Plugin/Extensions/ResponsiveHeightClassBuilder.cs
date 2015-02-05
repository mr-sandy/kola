namespace Linn.Responsive.Plugin.Extensions
{
    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsiveHeightClassBuilder
    {
        public static string BuildClasses(ResponsiveHeight responsiveHeight)
        {
            return BuildClasses(responsiveHeight, "height");
        }

        public static string BuildClassesForMin(ResponsiveHeight responsiveHeight)
        {
            return BuildClasses(responsiveHeight, "min-height");
        }

        public static string BuildClassesForMax(ResponsiveHeight responsiveHeight)
        {
            return BuildClasses(responsiveHeight, "max-height");
        }

        private static string BuildClasses(ResponsiveHeight responsiveHeight, string prefix)
        {
            switch (responsiveHeight.Height.Type)
            {
                case "auto":
                    return string.Format("{0}-auto-{1}", prefix, responsiveHeight.Grid);

                case "none":
                    return string.Format("{0}-none-{1}", prefix, responsiveHeight.Grid);

                case "fixed":
                    return string.Format("{0}-{1}-{2}", prefix, responsiveHeight.Height.Value.Replace(".5", "-and-a-half"), responsiveHeight.Grid);

                case "percentage":
                    return string.Format("{0}-{1}-vh-{2}", prefix, responsiveHeight.Height.Value, responsiveHeight.Grid);
            }

            return string.Empty;
        }
    }
}