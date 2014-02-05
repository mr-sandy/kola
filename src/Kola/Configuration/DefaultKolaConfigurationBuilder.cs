namespace Kola.Configuration
{
    using System;
    using System.Collections.Generic;

    using Kola.Configuration.Plugins;
    using Kola.Domain.Rendering;

    public class DefaultKolaConfigurationBuilder : KolaConfigurationBuilder
    {
        private readonly IPluginFinder pluginFinder;

        private readonly IObjectFactory objectFactory;

        public DefaultKolaConfigurationBuilder(IPluginFinder pluginFinder, IObjectFactory objectFactory)
        {
            this.pluginFinder = pluginFinder;
            this.objectFactory = objectFactory;
        }

        protected override IEnumerable<PluginConfiguration> FindPlugins()
        {
            return this.pluginFinder.FindPlugins();
        }

        protected override IRenderer BuildRenderer(Dictionary<string, Type> handlerMappings)
        {
            var handlerFactory = new HandlerFactory(handlerMappings, this.objectFactory);
            return new Renderer(handlerFactory);
        }
    }
}