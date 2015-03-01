namespace Kola.Resources
{
    using System.Collections.Generic;

    public class ContainerResource : ComponentResource
    {
        public string Name { get; set; }

        public IEnumerable<PropertyResource> Properties { get; set; }

        public IEnumerable<ComponentResource> Components { get; set; }

        public override string Type
        {
            get { return "container"; }
        }
    }
}