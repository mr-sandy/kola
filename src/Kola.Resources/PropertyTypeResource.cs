namespace Kola.Resources
{
    using System.Collections.Generic;

    public class PropertyTypeResource
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public IList<LinkResource> Links { get; set; }
    }
}