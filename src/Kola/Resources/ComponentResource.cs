namespace Kola.Resources
{
    using System.Collections.Generic;

    public abstract class ComponentResource
    {
        public abstract string Type { get; }

        public IEnumerable<int> Path { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }
    }
}
