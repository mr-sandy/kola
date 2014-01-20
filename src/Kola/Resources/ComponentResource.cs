
namespace Kola.Resources
{
    using System.Collections.Generic;

    public class ComponentResource : CompositeResource
    {
        public string Name { get; set; }

        public IEnumerable<ParameterResource> Parameters { get; set; }
    }
}
