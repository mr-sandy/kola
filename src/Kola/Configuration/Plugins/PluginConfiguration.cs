namespace Kola.Configuration.Plugins
{
    using System.Collections.Generic;

    using Kola.Configuration.Fluent;
    using Kola.Domain;

    public abstract class PluginConfiguration
    {
        private readonly List<IPluginComponentSpecification> components = new List<IPluginComponentSpecification>();

        public string ViewLocation { get; set; }

        internal IEnumerable<IPluginComponentSpecification> Components
        {
            get { return this.components; }
        }

        protected PluginConfigurer Configure
        {
            get { return new PluginConfigurer(this); }
        }

        internal void Add(IPluginComponentSpecification component)
        {
            this.components.Add(component);
        }

        internal void Add(ParameterTypeSpecification parameterType)
        {
        }
    }
}
