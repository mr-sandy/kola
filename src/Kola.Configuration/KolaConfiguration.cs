namespace Kola.Configuration
{
    using System.Collections.Generic;

    using Kola.Configuration.Plugins;
    using Kola.Domain.Rendering;

    public class KolaConfiguration 
    {
        public KolaConfiguration(IMultiRenderer multiRenderer, IEnumerable<PluginConfiguration> plugins)
        {
            this.Renderer = multiRenderer;
            this.Plugins = plugins;
        }

        public IMultiRenderer Renderer { get; set; }

        public IEnumerable<PluginConfiguration> Plugins { get; private set; }
    }
}