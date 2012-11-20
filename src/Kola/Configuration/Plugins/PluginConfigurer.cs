
namespace Kola.Configuration.Plugins
{
    public class PluginConfigurer
    {
        private readonly PluginConfiguration pluginConfiguration;

        internal PluginConfigurer(PluginConfiguration pluginConfiguration)
        {
            this.pluginConfiguration = pluginConfiguration;
        }

        public void ViewLocation(string viewLocation)
        {
            this.pluginConfiguration.ViewLocation = viewLocation;
        }

        public AtomConfigurer Atom(string atomName)
        {
            return new AtomConfigurer(this.pluginConfiguration, atomName);
        }

        public ContainerConfigurer Container(string containerName)
        {
            return new ContainerConfigurer(this.pluginConfiguration);
        }

        public ParameterTypeConfiguration ParameterType(string parameterTypeName)
        {
            throw new ParameterTypeConfiguration(this.pluginConfiguration);
        }
    }
}