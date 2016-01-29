namespace Kola.Configuration
{
    using System.Collections.Generic;

    using Kola.Configuration.Plugins;
    using Kola.Domain.Rendering;

    public class KolaConfiguration 
    {
        public KolaConfiguration(IEnumerable<PluginConfiguration> plugins)
        {
            this.Plugins = plugins;
        }

        public IEnumerable<PluginConfiguration> Plugins { get; private set; }
    }
}