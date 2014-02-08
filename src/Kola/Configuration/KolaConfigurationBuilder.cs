namespace Kola.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Configuration.Plugins;
    using Kola.Domain.Rendering;

    public abstract class KolaConfigurationBuilder
    {
        public KolaConfiguration Build()
        {
            var plugins = this.FindPlugins();

            var rendererMappings = plugins
                .SelectMany(c => c.Components)
                .ToDictionary(c => c.Name, c => c.RendererType);

            var renderer = this.BuildRenderer(rendererMappings);

            return new KolaConfiguration(renderer, plugins);
        }

        protected abstract IEnumerable<PluginConfiguration> FindPlugins();

        protected abstract IRenderer BuildRenderer(Dictionary<string, Type> rendererMappings);
    }
}
