namespace Linn.Responsive.Plugin.PropertyModels
{
    using System.Collections.Generic;

    internal interface IGridSettings
    {
        IEnumerable<string> BuildClassNames(string grid);
    }

    internal class GridPlacement : IGridSettings
    {
        public string Position { get; set; }

        public bool? Show { get; set; }

        public bool? Hide { get; set; }

        public IEnumerable<string> BuildClassNames(string grid)
        {
            if (!string.IsNullOrWhiteSpace(this.Position))
            {
                yield return
                    string.Equals(this.Position, "all")
                        ? string.Format("{0}-all", grid)
                        : string.Format("{0}{1}", grid, this.Position.Replace("-", string.Format("-{0}", grid)));
            }

            if (this.Show.HasValue)
            {
                yield return string.Format("{0}-show", grid);
            }

            if (this.Hide.HasValue)
            {
                yield return string.Format("{0}-hide", grid);
            }
        }
    }
}