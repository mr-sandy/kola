namespace Kola.Configuration
{
    using System.Collections.Generic;

    using Kola.Configuration.Plugins;
    using Kola.Rendering;

    public class KolaConfiguration 
    {
        public KolaConfiguration(IKolaEngine kolaEngine, IEnumerable<PluginConfiguration> plugins)
        {
            this.KolaEngine = kolaEngine;
            this.Plugins = plugins;
        }

        public IKolaEngine KolaEngine { get; private set; }

        public IEnumerable<PluginConfiguration> Plugins { get; private set; }
    }
}