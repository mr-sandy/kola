namespace Kola.Configuration.Plugins
{
    using System;
    using System.Collections.Generic;

    using Kola.Configuration.Fluent;
    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Specifications;

    public abstract class PluginConfiguration
    {
        private readonly List<IPluginComponentSpecification<IComponentWithProperties>> componentSpecifications = new List<IPluginComponentSpecification<IComponentWithProperties>>();
        private readonly List<string> propertyTypes = new List<string>();
        private readonly List<Type> sourceTypes = new List<Type>();

        protected PluginConfiguration(string pluginName)
        {
            this.PluginName = pluginName;
        }

        public string PluginName { get; private set; }

        public string ViewLocation { get; set; }

        public string PropertyEditor { get; set; }

        public string PropertyEditorStylesheet { get; set; }

        public IEnumerable<IPluginComponentSpecification<IComponentWithProperties>> ComponentTypeSpecifications => this.componentSpecifications;

        public IEnumerable<string> PropertyTypes => this.propertyTypes;

        protected PluginConfigurer Configure => new PluginConfigurer(this);

        public IEnumerable<Type> SourceTypes => this.sourceTypes;

        internal void Add(IPluginComponentSpecification<IComponentWithProperties> componentSpecification)
        {
            this.componentSpecifications.Add(componentSpecification);
        }

        internal void AddPropertyType(string propertyType)
        {
            this.propertyTypes.Add(propertyType);
        }

        internal void AddSourceType(Type sourceType)
        {
            this.sourceTypes.Add(sourceType);
        }
    }
}
