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

            var handlerMappings = plugins
                .SelectMany(c => c.Components)
                .ToDictionary(c => c.Name, c => c.HandlerType);

            var renderer = this.BuildRenderer(handlerMappings);

            return new KolaConfiguration(renderer, plugins);
        }

        protected abstract IEnumerable<PluginConfiguration> FindPlugins();

        protected abstract IRenderer BuildRenderer(Dictionary<string, Type> handlerMappings);
    }
}
