
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kola.Configuration.Plugins;

/*
 * Here's what we are going to do:
 * 
 * 1 - Make a bootstrapper that has generic knowledge of an IOC container
 * 2 - The bootstrapper builds the configuration and pops it into the container
 * 3 - The configuration is then available from the container
 * 4 - The bootstrapper is the one who does all the assembly scanning stuff
 * 5 - The configuration holds the handlers for all of the 
 */
namespace Kola.Configuration.Ideas
{
    public class KolaBootstrapper
    {
        public KolaConfiguration BuildConfiguration()
        {
            return new KolaConfiguration();
        }

        private void LoadPlugInConfiguration(KolaConfiguration kolaConfiguration)
        {
            var pluginTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(FindPlugins);

            foreach (var pluginType in pluginTypes)
            {
                var plugin = InstantiatePlugin(pluginType);

                kolaConfiguration.AddPlugInConfiguration(plugin.PluginConfiguration, pluginType.Assembly);
            }

        }

        private static IEnumerable<Type> FindPlugins(Assembly assembly)
        {
            return assembly.GetTypes().Where(t => (t != typeof(PluginBootstrapper)) && typeof(PluginBootstrapper).IsAssignableFrom(t));
        }

        private static PluginBootstrapper InstantiatePlugin(Type type)
        {
            return (PluginBootstrapper)type.GetConstructor(new Type[] { }).Invoke(new object[] { });
        }

    }

    public class KolaConfiguration
    {
        public IEnumerable<ViewLocation> ViewLocations { get; private set; }

        internal void Add,.PlugInConfiguration(PluginConfiguration pluginConfiguration, Assembly sourceAssembly)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewLocation {

        public ViewLocation(Assembly assembly, string location)
        {
            Assembly = assembly;
            Location = location;
        }

        public Assembly Assembly { get; private set; }

        public string Location { get; private set; }
    }
}
