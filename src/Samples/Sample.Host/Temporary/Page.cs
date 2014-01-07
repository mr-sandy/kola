namespace Sample.Host.Temporary
{
    using System.Collections.Generic;

    using Kola.Processing;

    public class Page : IPage
    {
        public IEnumerable<IComponent> Components { get; set; }
    }
}