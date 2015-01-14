namespace Kola.Configuration
{
    using System.Linq;

    using Kola.Domain.Rendering;

    public class KolaConfigurationBuilder 
    {
        public KolaConfiguration Build(IPluginFinder pluginFinder, IObjectFactory objectFactory)
        {
            var plugins = pluginFinder.FindPlugins();

            var rendererMappings = plugins.SelectMany(c => c.ComponentTypeSpecifications);

            // TODO {SC} Surely this has to happen in a better way?
            var rendererFactory = new RendererFactory(rendererMappings, objectFactory);
            var renderer = new PathAnnotatingMultiRenderer(new MultiRenderer(rendererFactory));

            var configuration = new KolaConfiguration(renderer, plugins);

            KolaConfigurationRegistry.Register(configuration);

            return configuration;
        }
    }
}