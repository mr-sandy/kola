namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Context;

    public class ContentDirectory
    {
        public ContentDirectory(string path, IEnumerable<IContextItem> contextItems)
        {
            this.Path = path;
            this.ContextItems = contextItems;
        }

        public string Path { get; }

        public IEnumerable<IContextItem> ContextItems { get; }
    }
}