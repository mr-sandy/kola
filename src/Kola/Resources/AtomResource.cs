namespace Kola.Resources
{
    using System.Collections.Generic;

    public class AtomResource : ComponentResource
    {
        public string Name { get; set; }

        public IEnumerable<ParameterResource> Parameters { get; set; }

        public override string Type
        {
            get { return "atom"; }
        }
    }
}