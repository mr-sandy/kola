namespace Kola.Resources
{
    using System.Collections.Generic;

    public class WidgetResource : ComponentResource
    {
        public string Name { get; set; }

        public IEnumerable<ParameterResource> Parameters { get; set; }

        public IEnumerable<AreaResource> Areas { get; set; }

        public override string Type
        {
            get { return "widget"; }
        }
    }
}