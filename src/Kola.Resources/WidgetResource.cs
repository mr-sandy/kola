namespace Kola.Resources
{
    using System.Collections.Generic;

    public class WidgetResource : ComponentResource
    {
        public string Name { get; set; }

        public IEnumerable<PropertyResource> Properties { get; set; }

        public IEnumerable<ComponentResource> Areas { get; set; }

        public string Comment { get; set; }

        public override string Type
        {
            get { return "widget"; }
        }
    }
}