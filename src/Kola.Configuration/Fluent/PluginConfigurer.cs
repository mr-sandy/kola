
namespace Kola.Configuration.Fluent
{
    using Kola.Configuration.Plugins;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Specifications;

    public class PluginConfigurer
    {
        private readonly PluginConfiguration configuration;

        internal PluginConfigurer(PluginConfiguration pluginConfiguration)
        {
            this.configuration = pluginConfiguration;
        }

        public void ViewLocation(string viewLocation)
        {
            this.configuration.ViewLocation = viewLocation;
        }

        public void PropertyEditor(string propertyEditor)
        {
            this.configuration.PropertyEditor = propertyEditor;
        }


        public void PropertyEditorStylesheets(string stylesheetName)
        {
            this.configuration.PropertyEditorStylesheet = stylesheetName;
        }

        public void Source<T>() where T : IDynamicSource
        {
            this.configuration.AddSourceType(typeof(T));
        }

        public ComponentConfigurer Container(string componentName)
        {
            var specification = new ContainerSpecification(componentName);

            this.configuration.Add(specification);

            return new ComponentConfigurer(specification);
        }

        public ComponentConfigurer Atom(string componentName)
        {
            var specification = new AtomSpecification(componentName);

            this.configuration.Add(specification);

            return new ComponentConfigurer(specification);
        }
    }
}