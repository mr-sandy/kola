namespace Kola.Resources
{
    using System.Collections.Generic;

    public class ParameterResource
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public ParameterValueResource Value { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }
    }
}