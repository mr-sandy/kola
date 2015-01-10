namespace Kola.Configuration.Plugins
{
    using System.Collections.Generic;

    using Kola.Configuration.Fluent;
    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;

    public abstract class PluginConfiguration
    {
        private readonly List<IPluginComponentSpecification<IComponentWithProperties>> componentSpecifications = new List<IPluginComponentSpecification<IComponentWithProperties>>();
        private readonly List<PropertyTypeSpecification> propertySpecifications = new List<PropertyTypeSpecification>();
        private readonly List<string> editorStylesheets = new List<string>();

        protected PluginConfiguration(string pluginName)
        {
            this.PluginName = pluginName;
        }

        public string PluginName { get; private set; }

        public string ViewLocation { get; set; }

        internal IEnumerable<IPluginComponentSpecification<IComponentWithProperties>> ComponentTypeSpecifications
        {
            get { return this.componentSpecifications; }
        }

        internal IEnumerable<PropertyTypeSpecification> PropertyTypeSpecifications
        {
            get { return this.propertySpecifications; }
        }

        internal IEnumerable<string> EditorStylesheets
        {
            get { return this.editorStylesheets; }
        }

        protected PluginConfigurer Configure
        {
            get { return new PluginConfigurer(this); }
        }

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
    }
}
