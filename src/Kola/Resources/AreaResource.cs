namespace Kola.Resources
{
    using System.Collections.Generic;

    public class AreaResource
    {
        public string Path { get; set; }
        
        public IEnumerable<ComponentResource> Components { get; set; }
    }
}