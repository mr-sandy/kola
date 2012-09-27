namespace Kola.Configuration
{
    public class Registry
    {
        private readonly PluginConfiguration pluginConfiguration;

        public Registry(PluginConfiguration pluginConfiguration)
        {
            this.pluginConfiguration = pluginConfiguration;
        }

        public AtomConfiguration Atom(string name)
        {
            return new AtomConfiguration(this.pluginConfiguration);
        }

        public AtomConfiguration Container(string name)
        {
            return new AtomConfiguration(this.pluginConfiguration);
        }

        public ParameterTypeConfiguration ParameterType(string name)
        {
            return new ParameterTypeConfiguration(this.pluginConfiguration);
        }
    }
}