using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kola.Model;

namespace Kola.Configuration.Ideas
{
    public class KolaHostConfiguration
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

        internal void AddPlugInConfiguration(PluginConfiguration pluginConfiguration)
        {
            this.viewLocations.Add(new ViewLocation(pluginConfiguration.GetType().Assembly, pluginConfiguration.ViewLocation));
        }

        public void GetHandler(IComponent component)
        {
            throw new NotImplementedException();
        }
    }
}