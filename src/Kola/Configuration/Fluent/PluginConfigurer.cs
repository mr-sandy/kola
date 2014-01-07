
namespace Kola.Configuration.Fluent
{
    using Kola.Configuration.Plugins;

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

        public ComponentConfigurer Component(string componentName)
        {
            var componentSpecification = new ComponentSpecification(componentName);

            this.configuration.Add(componentSpecification);

            return new ComponentConfigurer(componentSpecification);
        }

        public ParameterTypeConfigurer ParameterType(string parameterName)
        {
            var parameterTypeSpecification = new ParameterTypeSpecification(parameterName);

            this.configuration.Add(parameterTypeSpecification);

            return new ParameterTypeConfigurer(parameterTypeSpecification);
        }
    }
}