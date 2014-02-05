namespace Kola.Configuration
{
    using System.Collections.Generic;

    using Kola.Configuration.Plugins;
    using Kola.Domain.Rendering;

    public class KolaConfiguration 
    {
        public KolaConfiguration(IRenderer renderer, IEnumerable<PluginConfiguration> plugins)
        {
            this.Renderer = renderer;
            this.Plugins = plugins;
        }

        public IRenderer Renderer { get; private set; }

        public IEnumerable<PluginConfiguration> Plugins { get; private set; }
    }
}