using System.Collections.Generic;
using Kola.Configuration.Fluent;

namespace Kola.Configuration
{
    public abstract class PluginConfiguration
    {
        private readonly List<ComponentConfiguration> components = new List<ComponentConfiguration>();

        public string ViewLocation { get; set; }

        internal void Add(ComponentConfiguration componentConfiguration)
        {
            this.components.Add(componentConfiguration);
        }

        internal void Add(ParameterTypeConfiguration parameterTypeConfiguration)
        {
        }

        internal IEnumerable<ComponentConfiguration> ComponentConfigurations
        {
            get { return this.components; }
        }

        protected PluginConfigurer Configure
        {
            get { return new PluginConfigurer(this); }
        }
    }
}
