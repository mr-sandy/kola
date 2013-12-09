namespace Kola.Configuration.Ideas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;

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

        public void GetHandler(Component component)
        {
            throw new NotImplementedException();
        }

        internal void AddPlugInConfiguration(PluginConfiguration pluginConfiguration)
        {
            this.viewLocations.Add(new ViewLocation(pluginConfiguration.GetType().Assembly, pluginConfiguration.ViewLocation));
        }
    }
}