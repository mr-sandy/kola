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
        private readonly List<PropertyTypeSpecification> propertySpecifications = new List<PropertyTypeSpecification>();
        private readonly List<string> editorStylesheets = new List<string>();
        private readonly List<Type> sourceTypes = new List<Type>();

        protected PluginConfiguration(string pluginName)
        {
            this.PluginName = pluginName;
        }

        public string PluginName { get; private set; }

        public string ViewLocation { get; set; }

        public IEnumerable<IPluginComponentSpecification<IComponentWithProperties>> ComponentTypeSpecifications => this.componentSpecifications;

        public IEnumerable<PropertyTypeSpecification> PropertyTypeSpecifications => this.propertySpecifications;

        public IEnumerable<string> EditorStylesheets => this.editorStylesheets;

        protected PluginConfigurer Configure => new PluginConfigurer(this);

        public IEnumerable<Type> SourceTypes => this.sourceTypes;

        internal void Add(IPluginComponentSpecification<IComponentWithProperties> componentSpecification)
        {
            this.componentSpecifications.Add(componentSpecification);
        }

        internal void Add(PropertyTypeSpecification propertyTypeSpecification)
        {
            this.propertySpecifications.Add(propertyTypeSpecification);
        }

        internal void Add(string editorStylesheet)
        {
            this.editorStylesheets.Add(editorStylesheet);
        }

        internal void AddSourceType(Type sourceType)
        {
            this.sourceTypes.Add(sourceType);
        }
    }
}
