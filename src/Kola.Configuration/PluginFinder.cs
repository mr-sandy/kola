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
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(this.FindPlugins)
                .Select(t => t.GetConstructor(new Type[] { }))
                .Where(c => c != null)
                .Select(c => (PluginConfiguration)c.Invoke(new object[] { }))
                .ToArray();
        }

        private IEnumerable<Type> FindPlugins(Assembly assembly)
        {
            return assembly.GetMatchingTypes(t => (t != typeof(PluginConfiguration)) && typeof(PluginConfiguration).IsAssignableFrom(t));
        }
    }

    internal static class AssemblyExtensions
    {
        public static ICollection<Type> GetMatchingTypes(this Assembly assembly, Predicate<Type> predicate)
        {
            ICollection<Type> types = new List<Type>();
            try
            {
                types = assembly.GetTypes().Where(i => i != null && predicate(i) && i.Assembly == assembly).ToList();
            }
            catch (ReflectionTypeLoadException ex)
            {
                foreach (var theType in ex.Types)
                {
                    try
                    {
                        if (theType != null && predicate(theType) && theType.Assembly == assembly)
                        {
                            types.Add(theType);
                        }
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
            return types;
        }
    }
}