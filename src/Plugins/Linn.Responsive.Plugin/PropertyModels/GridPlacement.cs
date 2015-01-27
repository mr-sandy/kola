namespace Linn.Responsive.Plugin.PropertyModels
{
    using System.Collections.Generic;

    internal class GridPlacement : GridSettings
    {
        public string Position { get; set; }

        public bool? Shown { get; set; }

        public bool? Hidden { get; set; }

        public override IEnumerable<string> BuildClassNames()
        {
            if (!string.IsNullOrWhiteSpace(this.Position))
            {
                yield return
                    string.Equals(this.Position, "1-12")
                        ? string.Format("{0}-all", this.Grid)
                        : string.Format("{0}{1}", this.Grid, this.Position.Replace("-", string.Format("-{0}", this.Grid)));
            }

            if (this.Shown.HasValue)
            {
                yield return string.Format("{0}-show", this.Grid);
            }

            if (this.Hidden.HasValue)
            {
                yield return string.Format("{0}-hide", this.Grid);
            }
        }
    }
}