namespace Kola.Configuration.Plugins
{
    using System.Collections.Generic;

    using Kola.Configuration.Fluent;
    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public abstract class PluginConfiguration
    {
        private readonly List<IPluginComponentSpecification<IParameterisedComponent>> componentSpecifications = new List<IPluginComponentSpecification<IParameterisedComponent>>();
        private readonly List<ParameterTypeSpecification> parameterSpecifications = new List<ParameterTypeSpecification>();

        public string ViewLocation { get; set; }

        internal IEnumerable<IPluginComponentSpecification<IParameterisedComponent>> ComponentTypeSpecifications
        {
            get { return this.componentSpecifications; }
        }

        internal IEnumerable<ParameterTypeSpecification> ParameterTypeSpecifications
        {
            get { return this.parameterSpecifications; }
        }

        protected PluginConfigurer Configure
        {
            get { return new PluginConfigurer(this); }
        }

        internal void Add(IPluginComponentSpecification<IParameterisedComponent> componentSpecification)
        {
            this.componentSpecifications.Add(componentSpecification);
        }

        internal void Add(ParameterTypeSpecification parameterTypeSpecification)
        {
            this.parameterSpecifications.Add(parameterTypeSpecification);
        }
    }
}
