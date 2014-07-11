namespace Kola.Configuration.Plugins
{
    using System.Collections.Generic;

    using Kola.Configuration.Fluent;
    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public abstract class PluginConfiguration
    {
        private readonly List<IPluginComponentSpecification<IParameterisedComponent>> componentSpecifications = new List<IPluginComponentSpecification<IParameterisedComponent>>();

        public string ViewLocation { get; set; }

        internal IEnumerable<IPluginComponentSpecification<IParameterisedComponent>> ComponentSpecifications
        {
            get { return this.componentSpecifications; }
        }

        protected PluginConfigurer Configure
        {
            get { return new PluginConfigurer(this); }
        }

        internal void Add(IPluginComponentSpecification<IParameterisedComponent> componentSpecification)
        {
            this.componentSpecifications.Add(componentSpecification);
        }

        internal void Add(ParameterTypeSpecification parameterType)
        {
        }
    }
}
