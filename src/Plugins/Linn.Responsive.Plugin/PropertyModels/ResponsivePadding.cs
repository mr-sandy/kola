namespace Linn.Responsive.Plugin.PropertyModels
{
    using System.Collections.Generic;

    internal class ResponsiveEdges
    {
        public string Grid { get; set; }

        public IEnumerable<EdgeValue> Edges { get; set; }
    }
}