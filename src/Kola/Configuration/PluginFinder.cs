/*
 * Here's what we are going to do:
 * 
 * 1 - Make a bootstrapper that has generic knowledge of an IOC container
 * 2 - The bootstrapper builds the configuration and pops it into the container
 * 3 - The configuration is then available from the container
 * 4 - The bootstrapper is the one who does all the assembly scanning stuff
 * 5 - The configuration holds the handlers for all of the component types
 */
namespace Kola.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Kola.Configuration.Plugins;

    public class PluginFinder : IPluginFinder
    {
        public IEnumerable<PluginConfiguration> FindPlugins()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(this.FindPlugins);

            return types.Select(type => (PluginConfiguration)type.GetConstructor(new Type[] { }).Invoke(new object[] { }));
        }

        private IEnumerable<Type> FindPlugins(Assembly assembly)
        {
            return assembly.GetTypes().Where(t => (t != typeof(PluginConfiguration)) && typeof(PluginConfiguration).IsAssignableFrom(t));
        }
    }
}
