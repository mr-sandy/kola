namespace Sample.Host.Temporary
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Rendering;

    public class Page : IPage
    {
        public IEnumerable<IComponentInstance> Components { get; set; }
    }
}