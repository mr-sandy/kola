namespace Kola.Resources
{
    using System.Collections.Generic;

    public class AreaResource : ComponentResource
    {
        public IEnumerable<ComponentResource> Components { get; set; }

        public override string Type
        {
            get { return "area"; }
        }
    }
}