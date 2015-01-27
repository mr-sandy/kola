namespace Linn.Responsive.Plugin.PropertyModels
{
    using System.Collections.Generic;

    internal abstract class GridSettings
    {
        public string Grid { get; set; }

        public abstract IEnumerable<string> BuildClassNames();
    }
}