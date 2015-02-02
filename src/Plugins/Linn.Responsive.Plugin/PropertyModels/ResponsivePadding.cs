namespace Linn.Responsive.Plugin.PropertyModels
{
    using System.Collections.Generic;

    internal class ResponsivePadding
    {
        public string Grid { get; set; }

        public IEnumerable<EdgeValue> Edges { get; set; }
    }

    internal class EdgeValue
    {
        public string Edge { get; set; }

        public string Value { get; set; }
    }
}