namespace Kola.Configuration.Plugins
{
    using System.Collections.Generic;

    using Kola.Configuration.Fluent;

    public abstract class PluginConfiguration
    {
        private readonly List<ComponentSpecification> components = new List<ComponentSpecification>();

        public string ViewLocation { get; set; }

        internal IEnumerable<ComponentSpecification> Components
        {
            get { return this.components; }
        }

        protected PluginConfigurer Configure
        {
            get { return new PluginConfigurer(this); }
        }

        internal void Add(ComponentSpecification component)
        {
            this.components.Add(component);
        }

        internal void Add(ParameterTypeSpecification parameterType)
        {
        }
    }
}
