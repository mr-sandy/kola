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

        internal void AddPlugInConfiguration(PluginConfiguration pluginConfiguration, Assembly sourceAssembly)
        {
            this.viewLocations.Add(new ViewLocation(sourceAssembly, pluginConfiguration.ViewLocation));
        }

        public void GetHandler(Component component)
        {
            throw new NotImplementedException();
        }
    }
}