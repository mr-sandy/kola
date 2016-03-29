namespace Kola.Configuration.Plugins
{
    using System;
    using System.Collections.Generic;

    using Kola.Configuration.Fluent;
    using Kola.Domain.Composition;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    public abstract class PluginConfiguration
    {
        private readonly List<IPluginComponentSpecification<IComponentWithProperties>> componentSpecifications = new List<IPluginComponentSpecification<IComponentWithProperties>>();
        private readonly List<Type> sourceTypes = new List<Type>();
        private readonly List<Type> contextProviderTypes = new List<Type>();

        protected PluginConfiguration(string pluginName)
        {
            this.PluginName = pluginName;
        }

        public string PluginName { get; private set; }

        public string ViewLocation { get; set; }

        public string PropertyEditor { get; set; }

        public string PropertyEditorStylesheet { get; set; }

        public IEnumerable<IPluginComponentSpecification<IComponentWithProperties>> ComponentTypeSpecifications => this.componentSpecifications;

        protected PluginConfigurer Configure => new PluginConfigurer(this);

        public IEnumerable<Type> SourceTypes => this.sourceTypes;

        public IEnumerable<Type> ContextProviderTypes => this.contextProviderTypes;

        internal void Add(IPluginComponentSpecification<IComponentWithProperties> componentSpecification)
        {
            this.componentSpecifications.Add(componentSpecification);
        }

        internal void AddSourceType(Type sourceType)
        {
            this.sourceTypes.Add(sourceType);
        }

        internal void AddContextProviderType(Type sourceType)
        {
            this.contextProviderTypes.Add(sourceType);
        }

        public virtual void ConfigureContainer(IContainer container)
        {
        }
    }
}
