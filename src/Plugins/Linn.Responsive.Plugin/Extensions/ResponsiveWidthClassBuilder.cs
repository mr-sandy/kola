namespace Linn.Responsive.Plugin.Extensions
{
    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsiveWidthClassBuilder
    {
        public static string BuildClasses(ResponsiveWidth responsiveWidth)
        {
            return BuildClasses(responsiveWidth, "width");
        }

        public static string BuildClassesForMin(ResponsiveWidth responsiveWidth)
        {
            return BuildClasses(responsiveWidth, "min-width");
        }

        public static string BuildClassesForMax(ResponsiveWidth responsiveWidth)
        {
            return BuildClasses(responsiveWidth, "max-width");
        }

        private static string BuildClasses(ResponsiveWidth responsiveWidth, string prefix)
        {
            switch (responsiveWidth.Width.Type)
            {
                case "default":
                    return string.Format("{0}-default-{1}", prefix, responsiveWidth.Grid);

                case "fixed":
                    return string.Format("{0}-{1}-{2}", prefix, responsiveWidth.Width.Value.Replace(".5", "-and-a-half"), responsiveWidth.Grid);

                case "proportional":
                    return string.Format("{0}-{1}-{2}", prefix, responsiveWidth.Width.Value, responsiveWidth.Grid);

                case "view-height":
                    return string.Format("{0}-{1}-vh-{2}", prefix, responsiveWidth.Width.Value, responsiveWidth.Grid);
            }

            return string.Empty;
        }
    }
}