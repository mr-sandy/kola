namespace Linn.Responsive.Plugin.PropertyModels
{
    using System.Collections.Generic;

    internal class ResponsivePosition
    {
        public string Grid { get; set; }

        public IEnumerable<PositionOffset> Positions { get; set; }
    }
}