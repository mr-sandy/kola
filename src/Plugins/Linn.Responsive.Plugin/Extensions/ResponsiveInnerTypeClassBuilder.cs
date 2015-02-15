namespace Linn.Responsive.Plugin.Extensions
{
    using Linn.Responsive.Plugin.PropertyModels;

    internal static class ResponsiveInnerTypeClassBuilder
    {
        public static string BuildClasses(ResponsiveType responsiveInnerType)
        {
            switch (responsiveInnerType.Type)
            {
                case "full":
                    return string.Format("inner-{0}", responsiveInnerType.Grid);
                default:
                    return string.Format("inner-{0}-{1}", responsiveInnerType.Type, responsiveInnerType.Grid);
            }
        }
    }
}