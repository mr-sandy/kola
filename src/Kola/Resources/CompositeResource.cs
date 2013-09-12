namespace Kola.Resources
{
    using System.Collections.Generic;

    public class CompositeResource
    {
        public IEnumerable<ComponentResource> Components { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }
    }
}