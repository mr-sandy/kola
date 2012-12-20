
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kola.Configuration.Plugins;
using Kola.Model;
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
        public KolaConfiguration BuildConfiguration()
        {
            var kolaConfiguration = new KolaConfiguration();
            this.LoadPlugInConfiguration(kolaConfiguration);

            KolaRegistry.KolaEngine = new KolaEngine(kolaConfiguration);

            return kolaConfiguration;
        }

        private void LoadPlugInConfiguration(KolaConfiguration kolaConfiguration)
        {
            var pluginTypes = GetPluginTypes<PluginBootstrapper>();

            foreach (var pluginType in pluginTypes)
            {
                var plugin = Instantiate<PluginBootstrapper>(pluginType);

                kolaConfiguration.AddPlugInConfiguration(plugin.PluginConfiguration, pluginType.Assembly);
            }
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

    public class KolaConfiguration
    {
        private readonly List<ViewLocation> viewLocations = new List<ViewLocation>();

        public IEnumerable<ViewLocation> ViewLocations
        {
            get { return this.viewLocations; }
        }

        public IEnumerable<string> AssemblyNames
        {
            get { return this.viewLocations.Select(l => l.Assembly.FullName); }
        }

        internal void AddPlugInConfiguration(PluginConfiguration pluginConfiguration, Assembly sourceAssembly)
        {
            this.viewLocations.Add(new ViewLocation(sourceAssembly, pluginConfiguration.ViewLocation));
        }

        public void GetHandler(Component component)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewLocation
    {

        public ViewLocation(Assembly assembly, string location)
        {
            Assembly = assembly;
            Location = location;
        }

        public Assembly Assembly { get; private set; }

        public string Location { get; private set; }
    }
}
