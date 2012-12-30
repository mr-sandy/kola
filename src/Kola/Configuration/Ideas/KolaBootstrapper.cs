
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kola.Configuration.Plugins;
using Kola.Processing;

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
        public KolaHostConfiguration Bootstrap(IObjectFactory objectFactory)
        {
            var kolaConfiguration = new KolaHostConfiguration();

            var pluginTypes = GetPluginTypes<PluginBootstrapper>();

            var handlerMappings = new Dictionary<string, Type>();

            foreach (var pluginType in pluginTypes)
            {
                var plugin = Instantiate<PluginBootstrapper>(pluginType);

                kolaConfiguration.AddPlugInConfiguration(plugin.PluginConfiguration, pluginType.Assembly);

                foreach (var atom in plugin.PluginConfiguration.Atoms)
                {
                    handlerMappings.Add(atom.AtomName, atom.HandlerType);
                }
            }

            KolaRegistry.KolaEngine = new KolaEngine(new KolaEngineConfiguration(handlerMappings, objectFactory));

            return kolaConfiguration;
        }

        private IEnumerable<Type> GetPluginTypes<T>()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(FindPlugins<T>);
        }

        private static IEnumerable<Type> FindPlugins<T>(Assembly assembly)
        {
            return assembly.GetTypes().Where(t => (t != typeof(T)) && typeof(T).IsAssignableFrom(t));
        }

        private static T Instantiate<T>(Type type)
        {
            return (T)type.GetConstructor(new Type[] { }).Invoke(new object[] { });
        }

    }
}
