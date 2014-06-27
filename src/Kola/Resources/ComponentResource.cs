namespace Kola.Resources
{
    using System.Collections.Generic;

    public abstract class ComponentResource
    {
        public abstract string Type { get; }

        public string Path { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }
    }
}
