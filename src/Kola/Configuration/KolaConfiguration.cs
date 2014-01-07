namespace Kola.Configuration
{
    using System.Collections.Generic;

    using Kola.Rendering;

    public class KolaConfiguration 
    {
        public KolaConfiguration(KolaEngine kolaEngine, IEnumerable<PluginSummary> pluginSummaries)
        {
            this.KolaEngine = kolaEngine;
            this.PluginSummaries = pluginSummaries;
        }

        public KolaEngine KolaEngine { get; private set; }

        public IEnumerable<PluginSummary> PluginSummaries { get; private set; }
    }
}