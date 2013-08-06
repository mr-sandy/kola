
namespace Kola.Configuration.Fluent
{
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
            var componentConfiguration = new ComponentConfiguration(componentName);

            configuration.Add(componentConfiguration);

            return new ComponentConfigurer(componentConfiguration);
        }

        public ParameterTypeConfigurer ParameterType(string parameterName)
        {
            var parameterTypeConfiguration = new ParameterTypeConfiguration(parameterName);

            configuration.Add(parameterTypeConfiguration);

            return new ParameterTypeConfigurer(parameterTypeConfiguration);
        }
    }
}