namespace Kola.Resources
{
    using System.Collections.Generic;

    public class PropertyResource
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public PropertyValueResource Value { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }
    }
}