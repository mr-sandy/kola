namespace Kola.Configuration
{
    using System;
    using System.Collections.Generic;

    using Kola.Configuration.Plugins;
    using Kola.Domain.Composition;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

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

        protected override IMultiRenderer BuildRenderer(IEnumerable<IPluginComponentSpecification<IParameterisedComponent>> componentSpecifications)
        {
            var rendererFactory = new RendererFactory(componentSpecifications, this.objectFactory);

            //TODO Should only annotate paths on previews, not normal page renders
            return new PathAnnotatingMultiRenderer(new MultiRenderer(rendererFactory));
        }
    }
}