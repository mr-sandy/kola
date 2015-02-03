namespace Linn.Responsive.Plugin.PropertyModels
{
    using System.Collections.Generic;

    internal class ResponsiveBorders
    {
        public string Grid { get; set; }

        public IEnumerable<BorderWidth> Borders { get; set; }
    }
}