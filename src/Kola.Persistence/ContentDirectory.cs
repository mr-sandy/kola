namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Config;

    public class ContentDirectory
    {
        public ContentDirectory(string path, IConfiguration configuration)
        {
            this.Path = path;
            this.Configuration = configuration;
        }

        public string Path { get; }

        public IConfiguration Configuration { get; }
    }
}