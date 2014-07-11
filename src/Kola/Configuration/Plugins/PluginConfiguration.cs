namespace Kola.Configuration.Plugins
{
    using System.Collections.Generic;

    using Kola.Configuration.Fluent;
    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public abstract class PluginConfiguration
    {
        private readonly List<IPluginComponentSpecification<IParameterisedComponent>> components = new List<IPluginComponentSpecification<IParameterisedComponent>>();

        public string ViewLocation { get; set; }

        internal IEnumerable<IPluginComponentSpecification<IParameterisedComponent>> Components
        {
            get { return this.components; }
        }

        protected PluginConfigurer Configure
        {
            get { return new PluginConfigurer(this); }
        }

        internal void Add(IPluginComponentSpecification<IParameterisedComponent> component)
        {
            this.components.Add(component);
        }

        internal void Add(ParameterTypeSpecification parameterType)
        {
        }
    }
}
