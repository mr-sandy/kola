namespace Kola.Resources
{
    using System.Collections.Generic;

    public class ParameterTypeResource
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string DefaultValue { get; set; }

        public IList<LinkResource> Links { get; set; }
    }
}