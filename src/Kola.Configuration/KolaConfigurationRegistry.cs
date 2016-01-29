namespace Kola.Configuration
{
    using System.Collections.Generic;

    using Kola.Configuration.Plugins;
    using Kola.Domain.Rendering;

    public class KolaConfigurationRegistry : IKolaConfigurationRegistry
    {
        MultiRenderer IKolaConfigurationRegistry.Renderer => Renderer;

        IEnumerable<PluginConfiguration> IKolaConfigurationRegistry.Plugins => Plugins;

        public static IEnumerable<PluginConfiguration> Plugins { get; private set; }

        public static MultiRenderer Renderer { get; private set; }

        public static void RegisterRenderer(MultiRenderer renderer)
        {
            Renderer = renderer;
        }

        public static void RegisterPlugins(IEnumerable<PluginConfiguration> plugins)
        {
            Plugins = plugins;
        }
    }
}