namespace Kola.Configuration.Plugins
{
    using System.Collections.Generic;

    using Kola.Configuration.Fluent;
    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    public abstract class PluginConfiguration
    {
        private readonly List<IPluginComponentSpecification<INamedComponentTemplate>> components = new List<IPluginComponentSpecification<INamedComponentTemplate>>();

        public string ViewLocation { get; set; }

        internal IEnumerable<IPluginComponentSpecification<INamedComponentTemplate>> Components
        {
            get { return this.components; }
        }

        protected PluginConfigurer Configure
        {
            get { return new PluginConfigurer(this); }
        }

        internal void Add(IPluginComponentSpecification<INamedComponentTemplate> component)
        {
            this.components.Add(component);
        }

        internal void Add(ParameterTypeSpecification parameterType)
        {
        }
    }
}
