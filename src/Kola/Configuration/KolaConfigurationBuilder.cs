namespace Kola.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Configuration.Plugins;
    using Kola.Domain.Composition;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    public abstract class KolaConfigurationBuilder
    {
        public KolaConfiguration Build()
        {
            var plugins = this.FindPlugins();

            var rendererMappings = plugins.SelectMany(c => c.ComponentTypeSpecifications);

            var renderer = this.BuildRenderer(rendererMappings);

            return new KolaConfiguration(renderer, plugins);
        }

        protected abstract IEnumerable<PluginConfiguration> FindPlugins();

        protected abstract IMultiRenderer BuildRenderer(IEnumerable<IPluginComponentSpecification<IComponentWithProperties>> componentSpecifications);
    }
}
