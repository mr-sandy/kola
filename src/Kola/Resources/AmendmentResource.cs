namespace Kola.Resources
{
    using System.Collections.Generic;

    public abstract class AmendmentResource
    {
        public string Type { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }
    }
}