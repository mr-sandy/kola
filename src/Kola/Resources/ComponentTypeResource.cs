namespace Kola.Resources
{
    using System.Collections.Generic;

    public class ComponentTypeResource
    {
        public string Name { get; set; }

        public IList<LinkResource> Links { get; set; }
    }
}