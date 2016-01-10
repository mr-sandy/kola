namespace Kola.Resources
{
    using System.Collections.Generic;

    public class WidgetSpecificationResource
    {
        public IEnumerable<ComponentResource> Components { get; set; }

        public IEnumerable<LinkResource> Links { get; set; }
    }
}