namespace Kola.Configuration
{
    public class ParameterTypeConfiguration
    {
        private readonly PluginConfiguration pluginConfiguration;

        public ParameterTypeConfiguration(PluginConfiguration pluginConfiguration)
        {
            this.pluginConfiguration = pluginConfiguration;
        }

        public ParameterTypeConfiguration DefaultTo(string value)
        {
            return this;
        }

        public ParameterTypeConfiguration WithEditor(string editor)
        {
            return this;
        }
    }
}