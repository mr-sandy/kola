
namespace Kola.Resources
{
    using System.Collections.Generic;

    public class ComponentResource
    {
        public string Type { get; set; }

        public IEnumerable<ComponentResource> Components { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }
    }
}
