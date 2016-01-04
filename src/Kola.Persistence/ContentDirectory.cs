namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Context;

    public class ContentDirectory
    {
        public ContentDirectory(string path, IContext context)
        {
            this.Path = path;
            this.Context = context;
        }

        public string Path { get; }

        public IContext Context { get; }
    }
}