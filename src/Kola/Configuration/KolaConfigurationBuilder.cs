/*
 * The role of the bootstrapper:
 * 1. One-time scan of referenced assemblies to find plug-ins; for each plug-in:
 *    a. Add the view location to a list to be used by the host to resolve views
 *    b. Add the assembly to a list to be used by the host
 *    c. Add a handler for each component configuration: 
 * 2. Create a common instance of the kola engine and put it somewhere reusable
 */
namespace Kola.Configuration
{
    using System;
    using System.Collections.Generic;

    using Kola.Configuration.Plugins;
    using Kola.Processing;

    public abstract class KolaConfigurationBuilder
    {
        public KolaConfiguration Build()
        {
            var pluginSummaries = new List<PluginSummary>();
            var handlerMappings = new Dictionary<string, Type>();

            foreach (var pluginConfiguration in this.FindPlugins())
            {
                pluginSummaries.Add(new PluginSummary(pluginConfiguration.GetType().Assembly, pluginConfiguration.ViewLocation));

                foreach (var componentConfiguration in pluginConfiguration.ComponentConfigurations)
                {
                    handlerMappings.Add(componentConfiguration.Name, componentConfiguration.HandlerType);
                }
            }

            return new KolaConfiguration(new KolaEngine(this.BuildProcessor(handlerMappings)), pluginSummaries);
        }

        protected abstract IEnumerable<PluginConfiguration> FindPlugins();

        protected abstract IProcessor BuildProcessor(Dictionary<string, Type> handlerMappings);
    }
}
