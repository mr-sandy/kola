namespace Kola.Domain.DynamicSources
{
    using System.Collections.Generic;
    using System.Linq;

    public class DynamicSourceProvider : IDynamicSourceProvider
    {
        private readonly IEnumerable<IDynamicSource> sources;

        public DynamicSourceProvider(IEnumerable<IDynamicSource> sources)
        {
            this.sources = sources;
        }

        public IDynamicSource Get(string sourceName)
        {
            return this.sources.FirstOrDefault(s => s.Name == sourceName);
        }
    }
}