namespace Kola.Nancy.Modules
{
    using System;

    public class RenderQuery
    {
        public string ComponentPath { get; set; }

        public string Preview { get; set; }

        public bool IsPreview
        {
            get
            {
                return string.Equals(this.Preview, "y", StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}